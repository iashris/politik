using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cakeslice
{
    public class Toggle : MonoBehaviour
    {
		public bool isenabled;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
			if(isenabled)
            {
				Debug.Log ("Triggered");
                GetComponent<Outline>().enabled = !GetComponent<Outline>().enabled;
            }
        }
    }
}