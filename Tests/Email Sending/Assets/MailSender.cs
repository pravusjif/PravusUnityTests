using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class MailSender : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.CaptureScreenshot(Application.persistentDataPath + "/Screenshot.png");
		StartCoroutine("SendEmail");
		SendEmail();
		//Debug.Log(Application.persistentDataPath);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private IEnumerator SendEmail()
    {
		yield return new WaitForSeconds(2);
		
        // Create a System.Net.Mail.MailMessage object
        MailMessage message = new MailMessage();
 
        // Add a recipient
        message.To.Add("pravusjif@gmail.com");
 
        // Add a message subject
        message.Subject = "Email message from Pravus on C-Sharp";
 
        // Add a message body
        message.Body = "Test email message from LULULULUL";
		
		// Attach a file
	    System.Net.Mail.Attachment attachment;
	    attachment = new System.Net.Mail.Attachment(Application.persistentDataPath + "/Screenshot.png");
	    message.Attachments.Add(attachment);
 
        // Create a System.Net.Mail.MailAddress object and
        // set the sender email address and display name.
        message.From = new MailAddress("pravus@nastycloud.com", "Pravus on C-Sharp");
 
        // Create a System.Net.Mail.SmtpClient object
        // and set the SMTP host and port number
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
 
        // If your server requires authentication add the below code
        // =========================================================
        // Enable Secure Socket Layer (SSL) for connection encryption
        smtp.EnableSsl = true;
 
        // Do not send the DefaultCredentials with requests
        //smtp.UseDefaultCredentials = false;
		
        // Create a System.Net.NetworkCredential object and set
        // the username and password required by your SMTP account
        smtp.Credentials = (System.Net.ICredentialsByHost) new NetworkCredential("pravus@nastycloud.com", "nastynasty");
        // =========================================================
 
		// SSL Auth error Quick Fix [TODO: Find better solution, this is skiping the SSL check]
        ServicePointManager.ServerCertificateValidationCallback = 
            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
                { return true; };		
		
        // Send the message
        smtp.Send(message);
    }	
}
