using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSIRIWARDENAGE1_Test3.Utilities
{
    public static class BMI
    {
        public static double CalcBMI(double weight, double height)
        {
            
            // Calculate BMI
            double _bmi = weight / (height/100 * height/100);

            return _bmi;
        }

        public static string GetCategory(double _bmi)
        {
            string category;

            if (_bmi < 15)
            {
                category = "Very severely underweight";
            }
            else if (_bmi < 16)
            {
                category = "Severely underweight";
            }
            else if (_bmi < 18.5)
            {
                category = "Underweight";
            }
            else if (_bmi < 25)
            {
                category = "Normal";
            }
            //error: changed <=30 to <30
            else if (_bmi < 30)
            {
                category = "Overweight";
            }
            else if (_bmi < 35)
            {
                category = "Obese Class I (Moderately obese)";
            }
            else if (_bmi < 40)
            {
                category = "Obese Class II (Severely obese)";
            }
            else
            {
                category = "Obese Class III (Very Severely obese)";
            }
            return category;
        }
    }
}
