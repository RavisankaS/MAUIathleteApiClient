using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI.Tests
{
    [TestClass()]
    public class BMITests
    {
        // the class rounds calculations to 2 decimal places, use an appropriate delta.
        private const double Delta = 0.01;

        #region Unit Test - Part 1 - establish expected values
        /// <summary>
        /// UseCase1: Normal
        /// </summary>
        [TestMethod()]
        public void bmiValueTestUseCase1()
        {
            double height = 1.75;
            double weight = 75;
            string category;

            // Act
            double bmi = BMI.bmiValue(height, weight, out category);

            // Assert
            Assert.AreEqual(24.49, bmi, Delta);
            Assert.AreEqual("Normal", category);

        }

        /// <summary>
        /// UseCase2: Overweight
        /// </summary>
        [TestMethod()]
        public void bmiValueTestUseCase2()
        {
            double height = 2.0;
            double weight = 111;
            string category;

            // Act
            double bmi = BMI.bmiValue(height, weight, out category);

            // Assert
            Assert.AreEqual(27.75, bmi, Delta);
            Assert.AreEqual("Overweight", category);

        }

        /// <summary>
        /// UseCase3: Underweight
        /// </summary>
        [TestMethod()]
        public void bmiValueTestUseCase3()
        {
            double height = 1.64;
            double weight = 48;
            string category;

            // Act
            double bmi = BMI.bmiValue(height, weight, out category);

            // Assert
            Assert.AreEqual(17.85, bmi, Delta);
            Assert.AreEqual("Underweight", category);
        }

        /// <summary>
        /// UseCase4: Obese Class III (Very Severely obese)
        /// </summary>
        [TestMethod()]
        public void bmiValueTestUseCase4()
        {
            double height = 1.48;
            double weight = 104;
            string category;

            // Act
            double bmi = BMI.bmiValue(height, weight, out category);

            // Assert
            Assert.AreEqual(47.48, bmi, Delta);
            Assert.AreEqual("Obese Class III (Very Severely obese)", category);
        }

        /// <summary>
        /// UseCase5: Obese Class III (Very Severely obese)
        /// </summary>
        [TestMethod()]
        public void bmiValueTestUseCase5()
        {
            double height = 1.00;
            double weight = 64;
            string category;

            // Act
            double bmi = BMI.bmiValue(height, weight, out category);

            // Assert
            Assert.AreEqual(64.00, bmi, Delta);
            Assert.AreEqual("Obese Class III (Very Severely obese)", category);
        }

        /// <summary>
        /// UseCase6: Very severely underweight
        /// </summary>
        [TestMethod()]
        public void bmiValueTestUseCase6()
        {
            double height = 1.65;
            double weight = 40;
            string category;

            // Act
            double bmi = BMI.bmiValue(height, weight, out category);

            // Assert
            Assert.AreEqual(14.69, bmi, Delta);
            Assert.AreEqual("Very severely underweight", category);
        }
        #endregion

        #region Unit Test - Part 2 - expected exceptions
        /// <summary>
        /// BMWeightBelowZeroUseCase : weight = -1
        /// </summary>
        [TestMethod]
        public void BMWeightBelowZeroUseCase()
        {
            // Arrange
            double height = 1.7;
            double weight = -1;
            string category;


            // Act
            try
            {
                double bmi = BMI.bmiValue(height, weight, out category);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, BMI.WeightBelowZeroMessage);
                return;
            }
            Assert.Fail("Failed to get the expected exception.");
        }

        /// <summary>
        /// BMIHeightBelowZeroUseCase : height = -1.75
        /// </summary>
        [TestMethod]
        public void BMIHeightBelowZeroUseCase()
        {
            // Arrange
            double height = -1.75;
            double weight = 68.5;
            string category;

            // Act
            try
            {
                double bmi = BMI.bmiValue(height, weight, out category);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, BMI.HeightBelowZeroMessage);
                return;
            }
            Assert.Fail("Failed to get the expected exception.");
        }
        #endregion

        #region Unit Test - Part 3 - change of behavior
        /// <summary>
        /// CategoryChangeUseCase1: BMI=24.85
        /// </summary>
        [TestMethod]
        public void CategoryChangeUseCase1()
        {
            // Arrange
            double height = 1.8;
            double weight = 80.5;
            string expectedCategory = "Normal";

            // Act
            double bmi = BMI.bmiValue(height, weight, out string actualCategory);

            // Assert
            Assert.AreEqual(expectedCategory, actualCategory, "Category does not match.");
        }

        /// <summary>
        /// CategoryChangeUseCase2: BMI=29.94
        /// </summary>
        [TestMethod]
        public void CategoryChangeUseCase2()
        {
            // Arrange
            double height = 1.8;
            double weight = 97;
            string expectedCategory = "Overweight";

            // Act
            double bmi = BMI.bmiValue(height, weight, out string actualCategory);

            // Assert
            Assert.AreEqual(expectedCategory, actualCategory, "Category does not match.");
        }
    }
    #endregion
}