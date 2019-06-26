using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieCatalogueAppWPF.Validations
{
    class AreFieldsEmpty
    {
        public bool AreFieldsValid(string title, DateTime releasedDate, string summary, double rating, string genre)
        {
            if (string.IsNullOrWhiteSpace(title) || 
                string.IsNullOrWhiteSpace(releasedDate.ToString()) ||
                string.IsNullOrWhiteSpace(summary) || 
                string.IsNullOrWhiteSpace(rating.ToString()) ||
                string.IsNullOrWhiteSpace(genre))
            {
                MessageBox.Show("Fields cannot be empty!");
                return false;
            }

            return true;
        }
    }
}
