<Query Kind="Program">
  <NuGetReference>Mail.dll</NuGetReference>
  <Namespace>Limilabs.Client.SMTP</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
</Query>

void Main()
{
	var exception = TestSmtpResponseException.Create();
	(exception as SmtpResponseException).Dump();
}

/// <summary>
///    Nasty hacky class to create a new instance of SmtpResponseException.
/// </summary>
public class TestSmtpResponseException : SmtpResponseException
{
	protected TestSmtpResponseException(SerializationInfo info, StreamingContext context) : base(info, context) {}

	public static TestSmtpResponseException Create()
	{
		var info = new SerializationInfo(typeof (TestSmtpResponseException), new FormatterConverter());
		info.AddValue("ClassName", "foo");
		info.AddValue("Message", "bar");
		info.AddValue("InnerException", null);
		info.AddValue("HelpURL", null);
		info.AddValue("StackTraceString", null);
		info.AddValue("RemoteStackTraceString", null);
		info.AddValue("RemoteStackIndex", 0);
		info.AddValue("ExceptionMethod", null);
		info.AddValue("HResult", 1); // important, can't be 0
		info.AddValue("Source", null);
		return new TestSmtpResponseException(info, new StreamingContext(StreamingContextStates.Other)); // StreamingContextStates doesn't matter
	}
}