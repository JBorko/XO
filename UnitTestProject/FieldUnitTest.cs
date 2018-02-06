using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X_O_Game;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for FieldUnitTest
    /// </summary>
    [TestClass]
    public class FieldUnitTest
    {
        private bool _eventOcured;
        [TestMethod]
        public void TestThatFieldStateIsEmptyUponCreation()
        {
            Field field = new Field();
            Assert.AreEqual(field.State, FieldState.EMPTY);
        }
        [TestMethod]
        public void TestThatEventStatusChangedIsRaisedProperly()
        {
            Field field = new Field();
            _eventOcured = false;
            field.StatusChanged += Field_StatusChanged;

            field.State = FieldState.EMPTY;
            Assert.IsFalse(_eventOcured);

            field.State = FieldState.O;
            Assert.IsTrue(_eventOcured);

            _eventOcured = false;
            field.State = FieldState.X;
            Assert.IsFalse(_eventOcured);
        }

        private void Field_StatusChanged(object sender, StatusChangedArgs e)
        {
            _eventOcured = true;
        }
    }
}
