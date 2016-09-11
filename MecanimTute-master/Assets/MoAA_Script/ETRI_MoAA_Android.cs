using UnityEngine;
using System.Collections;

public class ETRI_MoAA_Android : MonoBehaviour {
	static ETRI_MoAA_Android instance = null;
	static GameObject container = null;

	public AndroidJavaClass myCls;
	public AndroidJavaObject myObj;

	public static ETRI_MoAA_Android getInstance
	{
		get{
			if(instance == null){
				container = new GameObject ();
				container.name = "ETRI_MoAA_Android";
				instance = container.AddComponent (typeof(ETRI_MoAA_Android)) as ETRI_MoAA_Android;
			}
			return instance;
		}
	}

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Initialize(string _apiCode, string _market){
		myCls = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		myObj = myCls.GetStatic<AndroidJavaObject>("currentActivity");
		myObj.Call ("Initialize", _apiCode, _market);
	}

	public int onAction(string _action, string _label){
		return myObj.Call<int>("onAction", _action, _label);
	}

	public int onAction(string _action, string _label, long _value){
		return myObj.Call<int>("onAction", _action, _label, _value);
	}

	public void setAge(int _age){
		myObj.Call ("setAge", _age);
	}

	public void setGender(string _gender){
		myObj.Call ("setGender", _gender);
	}

	public void useLocationService(){
		myObj.Call ("useLocationService");
	}

	public void error(string _type, string _stack, string _output){
		myObj.Call ("error", _type, _stack, _output);
	}

	public int m_data{ set; get; }
}
