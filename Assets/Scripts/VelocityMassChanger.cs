using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VelocityMassChanger : MonoBehaviour
{
    public TMP_InputField X, Y, Z;
    public GameObject planet;

    public void Accept_Click(){
        Vector3 temp = new Vector3();
        temp.x = string.IsNullOrEmpty(X.text) ? 0 : float.Parse(X.text);
        temp.y = string.IsNullOrEmpty(Y.text) ? 0 : float.Parse(Y.text);
        temp.z = string.IsNullOrEmpty(Z.text) ? 0 : float.Parse(Z.text);

        //planet.Body.Velocity = temp;
    }
}