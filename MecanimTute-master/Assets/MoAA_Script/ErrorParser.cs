using UnityEngine;
using System.Collections;

public class ErrorParser : MonoBehaviour {
	static ErrorParser instance = null;
	static GameObject container = null;

	public string type = "";
	public string output = "";
	public string stack = "";

	public static ErrorParser getInstance
	{
		get{
			if(instance == null){
				container = new GameObject ();
				container.name = "ErrorParser";
				instance = container.AddComponent (typeof(ErrorParser)) as ErrorParser;
			}
			return instance;
		}
	}

	void Awake(){
		
	}
	public void Create(){
		RegisterLog ();
	}
	public void RegisterLog(){
		#if UNITY_5//버전별로 5.0이상부턴 방식이 달라졌음
		Application.logMessageReceived += HandleLog;
		#else
		Application.RegisterLogCallback (HandleLog);
		#endif
	}
	public void HandleLog(string _logString, string _stackTrace, LogType _type) {
		type = _type.ToString();
		output = _logString;
		stack = _stackTrace;
		ETRI_MoAA.getInstance.error (type, stack, output);
	}
	public int m_data{ set; get; }
}
