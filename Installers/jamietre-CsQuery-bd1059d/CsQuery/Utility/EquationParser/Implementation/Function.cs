﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using CsQuery.ExtensionMethods;
using CsQuery;
using CsQuery.Utility.EquationParser;
using CsQuery.Utility.StringScanner;

namespace CsQuery.Utility.EquationParser.Implementation
{
    public abstract class Function : Operand, IFunction
    {
        #region constructors

        public Function(string name)
        {
            Name = name;
        }

        #endregion

        #region protected properties

        public IList<IOperand> Operands
        {
            get
            {
                return _Operands.AsReadOnly();
            }
        }
        protected List<IOperand> _Operands = new List<IOperand>();


        #endregion

        #region public properties
        
        
        public string Name
        {
            get;
            protected set;
        }

        public IEnumerable<IVariable> Variables
        {
            get {
                
                foreach (var operand in Operands)
                {
                    if (operand is IVariableContainer)
                    {
                        foreach (var variable in ((IVariableContainer)operand).Variables)
                        {
                            yield return variable;
                        }
                    }
                }
            }
        }

        public abstract int RequiredParmCount { get; }

        public abstract int MaxParmCount { get; }

        public abstract AssociationType AssociationType {get;}

        #endregion

        #region public methods

        public new IFunction Clone()
        {
            return (IFunction)CopyTo(GetNewInstance());
        }

        
        public void Compile()
        {
            throw new NotImplementedException();

            

        }

        //public new IFunction<U> CloneAs<U>() where U : IConvertible, IEquatable<U>
        //{
        //    var clone = (IFunction<U>)CloneAsImpl<U>();
        //    CopyOperands(clone);
        //    return clone;
        //}
        protected override IOperand CopyTo(IOperand operand)
        {
            IFunction func = (IFunction)operand;

            foreach (var item in Operands)
            {
                func.AddOperand(item.Clone());
            }
            return operand;
        }
    

        //protected override IOperand<U> CloneAsImpl<U>()
        //{
        //    throw new NotImplementedException();
        //}

        public virtual void AddOperand(IConvertible operand)
        {
            _Operands.Add(Utils.EnsureOperand(operand));
        }

        public override string ToString()
        {

            return Name + "(" + String.Join(",", Operands) + ")";
        }
        #endregion

        #region protected methods

        protected IOperand FirstOperand
        {
            get
            {
                if (Operands.Count > 0)
                {
                    return Operands[0];
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region Interface members

        #endregion
    }

    public abstract class Function<T> : Function, IFunction<T> where T : IConvertible
    {
        public Function(string name): base(name)
        {
            Name = name;
        }

        public new T Value
        {
            get { return (T)base.Value; }
        }

        public new IFunction<T> Clone()
        {
            return (IFunction<T>)Clone();
        }

        IOperand<T> IOperand<T>.Clone()
        {
            return Clone();
        }


     
    }

}
