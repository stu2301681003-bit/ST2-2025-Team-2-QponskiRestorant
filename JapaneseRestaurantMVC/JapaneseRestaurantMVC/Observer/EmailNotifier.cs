using JapaneseRestaurant.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace JapaneseRestaurant.Observer
{
    public class EmailNotifier : IReservationObserver
    {
        // Change these values to match your email settings
        private const string senderEmail = "your_email@gmail.com";
        private const string senderPassword = "your_app_password";
        private const string smtpServer = "smtp.gmail.com";
        private const int smtpPort = 587;

        public void Update(Reservation reservation)
        {
            try
            {
                // The recipient — can be the customer's email or your admin email
                string recipientEmail = reservation.Email ?? "restaurant@example.com";

                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    var mail = new MailMessage(senderEmail, recipientEmail)
                    {
                        Subject = "Reservation Confirmation",
                        Body = $"Hello {reservation.Name},\n\n" +
                               $"Your reservation for {reservation.Date} has been confirmed!\n\n" +
                               $"Thank you for choosing our Japanese Restaurant.\n\nBest regards,\nRestaurant Team"
                    };

                    client.Send(mail);
                }

                Console.WriteLine($"✅ Email sent successfully to {recipientEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to send email: {ex.Message}");
            }
        }
    }
}

//когато ReservationManager го уведоми за нова резервация,
//той реагира тук, като симулира изпращане на имейл