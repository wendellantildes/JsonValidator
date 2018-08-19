using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonValidatorTool;
using System.IO;
using System;

namespace JsonValidatorTool.Tests
{
    [TestClass]
    public class JsonValidatorVoidMethodTest
    {
        [TestMethod]
        public void ShouldNotThrowExceptionWhenJsonIsValid()
        {
            var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
            try
            {
                JsonValidator.Validate(json);
                Assert.IsTrue(true);
            }
            catch (JsonNotValidException)
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(JsonNotValidException))]
        public void ShouldThrowExceptionWhenJsonIsInvalid()
        {
            var json = JsonUtils.ReadText(JsonUtils.InvalidJsonFileName);
            JsonValidator.Validate(json);
        }
   

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowArgumentOutOfRangeExceptionWhenDepthIsSmallerThanZero()
        {
            var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
            JsonValidator.Validate(json, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonNotValidException))]
        public void ShouldThrowExceptionWhenJsonIsValidButDepthIsOne()
        {
            var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
            JsonValidator.Validate(json, 1);
        }

        [TestMethod]
        public void ShouldNotThrowExceptionWhenJsonIsValidWithDepthIsEight()
        {
            var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
            try
            {
                JsonValidator.Validate(json,8);
                Assert.IsTrue(true);
            }
            catch (JsonNotValidException)
            {
                Assert.IsFalse(false);
            }
        }
    }
}
