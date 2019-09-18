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
    public GameObject Box;
    public bool mAddModel = true;
    public float x=0, y=0, z=0;
    void Start()
    {
        x = 0.01f;
        y = 0.05f;
        z = 0.01f;

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

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => { });
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

                    CreateObj(selected);
                    Debug.Log(selected);
                    Debug.Log(Nselected);
                   
                    Debug.Log(al);
                    // Do something with snapshot...
                }
                 });
        // Do something with the data in args.Snapshot
     
    }

    void CreateObj(int a) {
        int i = 0;
        for (i = 0; i <= a; i++) {
            mAddModel = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mAddModel)
        {

            Debug.Log("x :" + x);
            Debug.Log("y :" + y);
            Debug.Log("z :" + z);

            Box = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Box.transform.parent = this.gameObject.transform;

            // Adjust scale and position 
            // (use localScale and localPosition to make it relative to the parent)
            Box.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            Box.transform.localPosition = new Vector3(0, y, 0);
            Box.transform.localRotation = Quaternion.identity;

            Box.gameObject.SetActive(true);
           // x = x + 0.1f;
            y = y + 0.8f;
            //z = z + 0.01f;
           // mAddModel = false;
        }

    }
}

