﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



Namespace Microsoft.Samples.Certificate

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://Microsoft.Samples.Certificate", ConfigurationName:="Microsoft.Samples.Certificate.ICalculator")> _
    Public Interface ICalculator

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.Samples.Certificate/ICalculator/GetCallerIdentity", ReplyAction:="http://Microsoft.Samples.Certificate/ICalculator/GetCallerIdentityResponse")> _
        Function GetCallerIdentity() As String

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.Samples.Certificate/ICalculator/Add", ReplyAction:="http://Microsoft.Samples.Certificate/ICalculator/AddResponse")> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.Samples.Certificate/ICalculator/Subtract", ReplyAction:="http://Microsoft.Samples.Certificate/ICalculator/SubtractResponse")> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.Samples.Certificate/ICalculator/Multiply", ReplyAction:="http://Microsoft.Samples.Certificate/ICalculator/MultiplyResponse")> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.Samples.Certificate/ICalculator/Divide", ReplyAction:="http://Microsoft.Samples.Certificate/ICalculator/DivideResponse")> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
    End Interface

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Interface ICalculatorChannel
        Inherits Microsoft.Samples.Certificate.ICalculator, System.ServiceModel.IClientChannel
    End Interface

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Partial Public Class CalculatorClient
        Inherits System.ServiceModel.ClientBase(Of Microsoft.Samples.Certificate.ICalculator)
        Implements Microsoft.Samples.Certificate.ICalculator

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub

        Public Function GetCallerIdentity() As String Implements Microsoft.Samples.Certificate.ICalculator.GetCallerIdentity
            Return MyBase.Channel.GetCallerIdentity
        End Function

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements Microsoft.Samples.Certificate.ICalculator.Add
            Return MyBase.Channel.Add(n1, n2)
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements Microsoft.Samples.Certificate.ICalculator.Subtract
            Return MyBase.Channel.Subtract(n1, n2)
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements Microsoft.Samples.Certificate.ICalculator.Multiply
            Return MyBase.Channel.Multiply(n1, n2)
        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements Microsoft.Samples.Certificate.ICalculator.Divide
            Return MyBase.Channel.Divide(n1, n2)
        End Function
    End Class
End Namespace
