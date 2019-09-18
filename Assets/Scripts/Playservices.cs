using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity;
using Firebase.Extensions;
using Firebase;


public class Playservices : MonoBehaviour
{
    Firebase.FirebaseApp app;
    // Start is called before the first frame update
    int al, selected, Nselected;
   public ModelPopup mP = new ModelPopup();

    void Start()
    {
        ModelPopup mP = new ModelPopup();
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {

                
                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //   app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
                Debug.Log(reference);
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }


        });


        FirebaseDatabase.DefaultInstance
  .GetReference("user")
  .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        FirebaseDatabase.DefaultInstance
            .GetReference("user")
            .GetValueAsync().ContinueWith(task => {
                 if (task.IsFaulted)
                 {
              // Handle the error...
                  }
                  else if (task.IsCompleted)
                  {
                  DataSnapshot snapshot = task.Result;
                    selected = (int)snapshot.Child("selected").ChildrenCount;
                    Nselected = (int)snapshot.Child("Nselected").ChildrenCount;
                    al = (int)snapshot.Child("al").ChildrenCount;

                    Debug.Log("Hellllooooo :" + snapshot.Child("al/IP0").Value);
                    Debug.Log(selected);
                    Debug.Log(Nselected);
                    mP.Create();
                    Debug.Log(al);
                    // Do something with snapshot...
                }
                 });
        // Do something with the data in args.Snapshot
        Debug.Log("Connected");
    }


    // Update is called once per frame
    void Update()
    {
  
    }
}

