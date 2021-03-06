﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WDE.Common.Annotations;
using WDE.Common.Parameters;

namespace WDE.SmartScriptEditor.Models
{
    public class ParameterValueHolder<T> : INotifyPropertyChanged
    {
        private T value;
        public T Value
        {
            get => value;
            set
            {
                if (Comparer<T>.Default.Compare(value, Value) == 0)
                    return;
                
                var old = this.value;
                this.value = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(String));
                OnValueChanged?.Invoke(this, old, value);
            }
        }

        private IParameter<T> parameter;
        public IParameter<T> Parameter
        {
            get => parameter;
            set
            {
                if (parameter == value)
                    return;
                
                parameter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(String));
            }
        }

        private bool isUsed;
        public bool IsUsed
        {
            get => isUsed; 
            set
            {
                isUsed = value;
                OnPropertyChanged();
            }
        }

        private string name;
        public string Name
        {
            get => name; 
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string String => ToString();

        public override string ToString()
        {
            return parameter.ToString(value);
        }

        public ParameterValueHolder(IParameter<T> parameter)
        {
            IsUsed = false;
            Name = null;
            this.parameter = parameter;
        }

        public ParameterValueHolder(string name, IParameter<T> parameter)
        {
            Name = name;
            IsUsed = true;
            this.parameter = parameter;
        }

        public void Copy(ParameterValueHolder<T> other)
        {
            Name = other.Name;
            IsUsed = other.IsUsed;
            Value = other.Value;
            Parameter = other.Parameter;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public event System.Action<ParameterValueHolder<T>, T, T> OnValueChanged;
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName]  string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}