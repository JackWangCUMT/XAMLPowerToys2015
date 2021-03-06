﻿namespace XamlPowerToys.Model {
    using System;
    using System.ComponentModel;
    using XamlPowerToys.Model.Infrastructure;

    [Serializable]
    public class ControlDefinition {

        public ControlType ControlType { get; }

        public ProjectType ProjectType { get; }

        public String ShortName { get; }

        public ControlDefinition(ControlType controlType) {
            if (!Enum.IsDefined(typeof(ControlType), controlType)) {
                throw new InvalidEnumArgumentException(nameof(controlType), (Int32)controlType, typeof(ControlType));
            }

            this.ControlType = controlType;

            var value = controlType.ToString();

            if (value.StartsWith(Constants.Wpf)) {
                this.ProjectType = ProjectType.Wpf;
                this.ShortName = value.Substring(3).SplitWords();
            } else if (value.StartsWith(Constants.Xamarin)) {
                this.ProjectType = ProjectType.Xamarin;
                this.ShortName = value.Substring(7).SplitWords();
            } else {
                this.ProjectType = ProjectType.Uwp;
                this.ShortName = value.Substring(3).SplitWords();
            }
        }

        public override String ToString() {
            return this.ShortName;
        }

    }
}
