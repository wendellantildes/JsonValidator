using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonValidatorTool;
using System.IO;
using System;

namespace JsonValidatorTool.Tests
{
    [TestClass]
    public class JsonValidatorBooleanMethodTest
    {
        [TestMethod]
        public void ShouldReturnTrueWhenJsonIsValid()
        {
            var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
            Assert.IsTrue(JsonValidator.IsValid(json));
        }

        [TestMethod]
        public void ShouldReturnFalseWhenJsonIsInvalid()
        {
            var json = JsonUtils.ReadText(JsonUtils.InvalidJsonFileName);
            Assert.IsFalse(JsonValidator.IsValid(json));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowArgumentOutOfRangeExceptionWhenDepthIsSmallerThanZero()
        {
            var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
            JsonValidator.IsValid(json, -1);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenJsonIsValidButDepthIsOne()
        {
            var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
            Assert.IsFalse(JsonValidator.IsValid(json, 1));
        }

        [TestMethod]
        public void ShouldReturnTrueWhenJsonIsValidWithDepthIsEight()
        {
            var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
            Assert.IsTrue(JsonValidator.IsValid(json, 8));
        }
    }
}
