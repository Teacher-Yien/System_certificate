using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_certificate.Views
{
    // Views/IEnrollstudentsView.cs  
    public interface IEnrollstudentsView
    {
        string FirstName { get; }
        string LastName { get; }
        string Major { get; }
        string CourseName { get; }
        string CourseDuration { get; }
        void ClearFields();
        void ShowMessage(string message);
    }
}
