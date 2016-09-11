using UnityEngine;
using System;
using System.Collections;

public class ETRI_MoAA : MonoBehaviour{
	static ETRI_MoAA instance = null;
	static GameObject container = null;

	private string API_CODE = "643e23c4-4705-11e6-a23f-5626dfb797db";
	private string MARKET = "Google Play";

	public static ETRI_MoAA getInstance
	{
		get{
			if(instance == null){
				container = new GameObject ();
				container.name = "ETRI_MoAA";
				instance = container.AddComponent (typeof(ETRI_MoAA)) as ETRI_MoAA;
			}
			return instance;
		}
	}
	// Use this for initialization
	void Awake () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Create (){
		ErrorParser.getInstance.Create ();
	}
	public void Initialize(){
		#if UNITY_ANDROID
		ETRI_MoAA_Android.getInstance.Initialize (API_CODE, MARKET);
		#elif UNITY_IPHONE
		#endif
	}

	public int onAction(string _action, string _label){
		#if UNITY_ANDROID 
		return ETRI_MoAA_Android.getInstance.onAction (_action, _label);
		#elif UNITY_IPHONE
		#endif
	}

	public int onAction(string _action, string _label, long _value){
		#if UNITY_ANDROID
		return ETRI_MoAA_Android.getInstance.onAction (_action, _label, _value);
		#elif UNITY_IPHONE
		#endif
	}

	public void setAge(int _age){
		#if UNITY_ANDROID
		ETRI_MoAA_Android.getInstance.setAge (_age);
		#elif UNITY_IPHONE
		#endif
	}

	public void setGender(string _gender){
		#if UNITY_ANDROID
		ETRI_MoAA_Android.getInstance.setGender (_gender);
		#elif UNITY_IPHONE
		#endif
	}

	public void useLocationService(){
		#if UNITY_ANDROID
		ETRI_MoAA_Android.getInstance.useLocationService ();
		#elif UNITY_IPHONE
		#endif
	}

	public void error(string _type, string _stack, string _output){
		#if UNITY_ANDROID
		ETRI_MoAA_Android.getInstance.error (_type, _stack, _output);
		#elif UNITY_IPHONE
		#endif
	}
	public int m_data{ set; get; }
}//안드로이드 아오에스 따로 만들고 여기에 통합하는식으로 하자
