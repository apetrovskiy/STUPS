// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System;
using System.Globalization;
using System.Windows;
using System.Diagnostics;
using UIAComWrapperInternal;

namespace System.Windows.Automation
{
    public abstract class Condition
    {
        
        public static readonly Condition FalseCondition = BoolCondition.Wrap(false);
        public static readonly Condition TrueCondition = BoolCondition.Wrap(true);

        internal abstract UIAutomationClient.IUIAutomationCondition NativeCondition { get; }

        internal static Condition Wrap(UIAutomationClient.IUIAutomationCondition obj)
        {
            if (obj is UIAutomationClient.IUIAutomationBoolCondition)
                return new BoolCondition((UIAutomationClient.IUIAutomationBoolCondition)obj);
            else if (obj is UIAutomationClient.IUIAutomationAndCondition)
                return new AndCondition((UIAutomationClient.IUIAutomationAndCondition)obj);
            else if (obj is UIAutomationClient.IUIAutomationOrCondition)
                return new OrCondition((UIAutomationClient.IUIAutomationOrCondition)obj);
            else if (obj is UIAutomationClient.IUIAutomationNotCondition)
                return new NotCondition((UIAutomationClient.IUIAutomationNotCondition)obj);
            else if (obj is UIAutomationClient.IUIAutomationPropertyCondition)
                return new PropertyCondition((UIAutomationClient.IUIAutomationPropertyCondition)obj);
            else
                throw new ArgumentException("obj");
        }

        internal static UIAutomationClient.IUIAutomationCondition ConditionManagedToNative(
            Condition condition)
        {
            return (condition == null) ? null : condition.NativeCondition;
        }

        internal static UIAutomationClient.IUIAutomationCondition[] ConditionArrayManagedToNative(
            Condition[] conditions)
        {
            UIAutomationClient.IUIAutomationCondition[] unwrappedConditions =
                new UIAutomationClient.IUIAutomationCondition[conditions.Length];
            for (int i = 0; i < conditions.Length; ++i)
            {
                unwrappedConditions[i] = ConditionManagedToNative(conditions[i]);
            }
            return unwrappedConditions;
        }

        internal static Condition[] ConditionArrayNativeToManaged(
            Array conditions)
        {
            Condition[] wrappedConditions = new Condition[conditions.Length];
            for (int i = 0; i < conditions.Length; ++i)
            {
                wrappedConditions[i] = Wrap((UIAutomationClient.IUIAutomationCondition)conditions.GetValue(i));
            }
            return wrappedConditions;
        }

        
        private class BoolCondition : Condition
        {
            
            internal UIAutomationClient.IUIAutomationBoolCondition _obj;

            internal BoolCondition(UIAutomationClient.IUIAutomationBoolCondition obj)
            {
                Debug.Assert(obj != null);
                this._obj = obj;
            }

            internal override UIAutomationClient.IUIAutomationCondition NativeCondition
            {
                get { return this._obj; }
            }

            internal static BoolCondition Wrap(bool b)
            {
                UIAutomationClient.IUIAutomationBoolCondition obj = (UIAutomationClient.IUIAutomationBoolCondition)((b) ?
                    Automation.Factory.CreateTrueCondition() :
                    Automation.Factory.CreateFalseCondition());
                return new BoolCondition(obj);
            }
        }
    }

    public class NotCondition : Condition
    {
        
        internal UIAutomationClient.IUIAutomationNotCondition _obj;

        
        internal NotCondition(UIAutomationClient.IUIAutomationNotCondition obj)
        {
            Debug.Assert(obj != null);
            this._obj = obj;
        }

        public NotCondition(Condition condition)
        {
            this._obj = (UIAutomationClient.IUIAutomationNotCondition)
                Automation.Factory.CreateNotCondition(
                ConditionManagedToNative(condition));
        }

        internal override UIAutomationClient.IUIAutomationCondition NativeCondition
        {
            get { return this._obj; }
        }

        
        public Condition Condition
        {
            get
            {
                return Wrap(this._obj.GetChild());
            }
        }
    }
    
    public class AndCondition : Condition
    {
        
        internal UIAutomationClient.IUIAutomationAndCondition _obj;

        
        internal AndCondition(UIAutomationClient.IUIAutomationAndCondition obj)
        {
            Debug.Assert(obj != null);
            this._obj = obj;
        }

        public AndCondition(params Condition[] conditions)
        {
            this._obj = (UIAutomationClient.IUIAutomationAndCondition)
                Automation.Factory.CreateAndConditionFromArray(
                ConditionArrayManagedToNative(conditions));
        }

        internal override UIAutomationClient.IUIAutomationCondition NativeCondition
        {
            get { return this._obj; }
        }

        public Condition[] GetConditions()
        {
            return ConditionArrayNativeToManaged(this._obj.GetChildren());
        }
    }

    public class OrCondition : Condition
    {
        
        internal UIAutomationClient.IUIAutomationOrCondition _obj;

        
        internal OrCondition(UIAutomationClient.IUIAutomationOrCondition obj)
        {
            Debug.Assert(obj != null);
            this._obj = obj;
        }

        public OrCondition(params Condition[] conditions)
        {
            this._obj = (UIAutomationClient.IUIAutomationOrCondition)
                Automation.Factory.CreateOrConditionFromArray(
                ConditionArrayManagedToNative(conditions));
        }

        internal override UIAutomationClient.IUIAutomationCondition NativeCondition
        {
            get { return this._obj; }
        }

        public Condition[] GetConditions()
        {
            return ConditionArrayNativeToManaged(this._obj.GetChildren());
        }
    }

    [Flags]
    public enum PropertyConditionFlags
    {
        None,
        IgnoreCase
    }

    public class PropertyCondition : Condition
    {
        
        internal UIAutomationClient.IUIAutomationPropertyCondition _obj;

        
        internal PropertyCondition(UIAutomationClient.IUIAutomationPropertyCondition obj)
        {
            Debug.Assert(obj != null);
            this._obj = obj;
        }

        public PropertyCondition(AutomationProperty property, object value)
        {
            this.Init(property, value, PropertyConditionFlags.None);
        }

        public PropertyCondition(AutomationProperty property, object value, PropertyConditionFlags flags)
        {
            this.Init(property, value, flags);
        }

        private void Init(AutomationProperty property, object val, PropertyConditionFlags flags)
        {
            Utility.ValidateArgumentNonNull(property, "property");

            this._obj = (UIAutomationClient.IUIAutomationPropertyCondition)
                Automation.Factory.CreatePropertyConditionEx(
                property.Id,
                Utility.UnwrapObject(val), 
                (UIAutomationClient.PropertyConditionFlags)flags);
        }

        internal override UIAutomationClient.IUIAutomationCondition NativeCondition
        {
            get { return this._obj; }
        }

        
        public PropertyConditionFlags Flags
        {
            get
            {
                return (PropertyConditionFlags)this._obj.PropertyConditionFlags;
            }
        }

        public AutomationProperty Property
        {
            get
            {
                return AutomationProperty.LookupById(this._obj.propertyId);
            }
        }

        public object Value
        {
            get
            {
                return this._obj.PropertyValue;
            }
        }
    }
}
