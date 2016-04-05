using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MailMessage msg = new MailMessage();
        msg.To.Add(new MailAddress("destinatario@correo.com", "Nombre_Destinatario"));
        msg.From = new MailAddress("tucorreo@correo.com", "Tu_Nombre");
        msg.Subject = "Envío utilizando SendGrid con Microsoft Azure.";
        msg.Body = "Mensaje de prueba utilizando SendGrid";
        msg.IsBodyHtml = true;
        Attachment objAttach = new Attachment(@"C:\Users\usuario\Pictures\2016-04-05_0720.png");
        objAttach.ContentId = "attach01";
        objAttach.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
        msg.Attachments.Add(objAttach);

        SmtpClient client = new SmtpClient();
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("azure_9999@azure.com", "9999");
        client.Port = 587;
        client.Host = "smtp.sendgrid.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = false;
        try
        {
            client.Send(msg);
            statusLabel.Text = "Mensaje enviado correctamente";
        }
        catch (Exception ex)
        {
            statusLabel.Text = ex.ToString();
        }
    }
}