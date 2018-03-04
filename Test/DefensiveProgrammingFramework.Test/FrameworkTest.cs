using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test
{
    [TestClass]
    public class FrameworkTest
    {
        #region Public Methods

        [DataRow(typeof(ObjectIsExtensions), typeof(ObjectIsNotExtensions), typeof(ObjectCannotExtensions), typeof(ObjectMustExtensions), typeof(ObjectWhenExtensions), typeof(ObjectWhenNotExtensions), new string[] { "Is=>Be", "Does=>" })]
        [DataRow(typeof(CollectionIsExtensions), typeof(CollectionIsNotExtensions), typeof(CollectionCannotExtensions), typeof(CollectionMustExtensions), typeof(CollectionWhenExtensions), typeof(CollectionWhenNotExtensions), new string[] { "Is=>Be", "Contains=>Contain" })]
        [DataRow(typeof(FileIsExtensions), typeof(FileIsNotExtensions), typeof(FileCannotExtensions), typeof(FileMustExtensions), typeof(FileWhenExtensions), typeof(FileWhenNotExtensions), new string[] { "Is=>Be", "Does=>" })]
        [DataTestMethod]
        public void TestNamingConvention(Type isExtensions, Type isNotExtensions, Type cannotExtensions, Type mustExtensions, Type whenExtensions, Type whenNotExtensions, string[] prefixes)
        {
            var prefixes2 = prefixes.ToDictionary(x => x.Split(new string[] { "=>" }, StringSplitOptions.None)[0],
                                                  x => x.Split(new string[] { "=>" }, StringSplitOptions.None)[1]);

            // check if classes are static
            this.TestClass(isExtensions);
            this.TestClass(isNotExtensions);
            this.TestClass(cannotExtensions);
            this.TestClass(mustExtensions);
            this.TestClass(whenExtensions);
            this.TestClass(whenNotExtensions);

            foreach (var method in isExtensions.GetMethods(BindingFlags.Public |
                                                           BindingFlags.Static |
                                                           BindingFlags.DeclaredOnly))
            {
                var prefix = prefixes2.First(x => method.Name.StartsWith(x.Key)).Key;
                var suffix = method.Name.Substring(prefix.Length);
                var substitute = prefixes2[prefix];

                var isNotMethodName = $"{prefix}Not{suffix}";
                var cannotMethodName = $"Cannot{substitute}{suffix}";
                var mustMethodName = $"Must{substitute}{suffix}";
                var whenMethodName = $"When{prefix}{suffix}";
                var whenNotMethodName = $"When{prefix}Not{suffix}";

                if (method.Name == "IsMatch")
                {
                    cannotMethodName = "CannotMatch";
                    mustMethodName = "MustMatch";
                    whenMethodName = "WhenDoesMatch";
                    whenNotMethodName = "WhenDoesNotMatch";
                }

                // check if naming convention
                this.TestMethodName(isExtensions, method.Name);
                this.TestMethodName(isNotExtensions, isNotMethodName);
                this.TestMethodName(cannotExtensions, cannotMethodName);
                this.TestMethodName(mustExtensions, mustMethodName);
                this.TestMethodName(whenExtensions, whenMethodName);
                this.TestMethodName(whenNotExtensions, whenNotMethodName);

                // check parameters
                this.TestParameters(method, isNotExtensions.GetMethod(isNotMethodName), false);
                this.TestParameters(method, cannotExtensions.GetMethod(cannotMethodName), false);
                this.TestParameters(method, mustExtensions.GetMethod(mustMethodName), false);
                this.TestParameters(method, whenExtensions.GetMethod(whenMethodName), true);
                this.TestParameters(method, whenNotExtensions.GetMethod(whenNotMethodName), true);

                // check return types
                this.TestReturnType(method, typeof(bool));
                this.TestReturnType(isNotExtensions.GetMethod(isNotMethodName), method.ReturnType);
                this.TestReturnType(cannotExtensions.GetMethod(cannotMethodName), method.GetParameters()[0].ParameterType);
                this.TestReturnType(mustExtensions.GetMethod(mustMethodName), method.GetParameters()[0].ParameterType);
                this.TestReturnType(whenExtensions.GetMethod(whenMethodName), method.GetParameters()[0].ParameterType);
                this.TestReturnType(whenNotExtensions.GetMethod(whenNotMethodName), method.GetParameters()[0].ParameterType);
            }

            // check if method count equals
            this.TestMethodCount(isExtensions, isNotExtensions);
            this.TestMethodCount(isExtensions, cannotExtensions);
            this.TestMethodCount(isExtensions, mustExtensions);
            this.TestMethodCount(isExtensions, whenExtensions);
            this.TestMethodCount(isExtensions, whenNotExtensions);
        }

        #endregion Public Methods

        #region Private Methods

        private void TestClass(Type type)
        {
            if (!type.IsAbstract ||
                !type.IsSealed)
            {
                Assert.Fail($"Type {type.Name} must be static.");
            }
        }

        private void TestMethodCount(Type type1, Type type2)
        {
            if (type1.GetMethods(BindingFlags.DeclaredOnly).Length != type2.GetMethods(BindingFlags.DeclaredOnly).Length)
            {
                Assert.Fail($"Method count in {type1} does not match method count in {type2}");
            }
        }

        private void TestMethodModifiers(MethodInfo method)
        {
            if (!method.IsStatic)
            {
                Assert.Fail($"Method {method.Name} should be static.");
            }
            else if (!method.IsPublic)
            {
                Assert.Fail($"Method {method.Name} should be public.");
            }
            else if (!method.IsDefined(typeof(ExtensionAttribute), false))
            {
                Assert.Fail($"Method {method.Name} should be an extension method.");
            }
        }

        private void TestMethodName(Type type, string methodName)
        {
            var methods = type.GetMethods();

            if (!methods.Any(x => x.Name == methodName))
            {
                Assert.Fail($"Missing method {methodName} in {type}");
            }
            else
            {
                methods.Where(x => x.Name == methodName).ToList().ForEach(x => this.TestMethodModifiers(x));
            }
        }

        private void TestParameters(MethodInfo methodInfo1, MethodInfo methodInfo2, bool containsDefaultValue)
        {
            var parameters1 = methodInfo1.GetParameters();
            var parameters2 = methodInfo2.GetParameters();

            if (parameters1.Length != parameters2.Length + (containsDefaultValue ? -1 : 0))
            {
                Assert.Fail($"Method {methodInfo1.Name} parameters do not match {methodInfo2.Name}.");
            }
            else
            {
                if (methodInfo1.IsGenericMethod != methodInfo2.IsGenericMethod)
                {
                    Assert.Fail($"Method {methodInfo1.Name} generic parameters do not match {methodInfo2.Name}.");
                }

                for (int i = 0; i < parameters1.Length; i++)
                {
                    if (parameters1[i].Name != parameters2[i].Name)
                    {
                        Assert.Fail($"Method {methodInfo1.Name} parameters names do not match {methodInfo2.Name} ({parameters2[i].Name})).");
                    }
                    else if (parameters1[i].ParameterType.Name != parameters2[i].ParameterType.Name)
                    {
                        Assert.Fail($"Method {methodInfo1.Name} parameters types do not match {methodInfo2.Name} ({parameters2[i].ParameterType}).");
                    }
                }

                if (containsDefaultValue)
                {
                    if (parameters2.Last().Name != "defaultValue")
                    {
                        Assert.Fail($"Method {methodInfo2.Name} does not have last parameter named defaultValue.");
                    }
                }
            }
        }

        private void TestReturnType(MethodInfo methodInfo1, Type returnType)
        {
            if (methodInfo1.ReturnType.Name != returnType.Name)
            {
                Assert.Fail($"Method {methodInfo1.Name} returns incorrect return type.");
            }
        }

        #endregion Private Methods
    }
}