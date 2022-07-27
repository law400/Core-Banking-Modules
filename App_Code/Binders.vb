Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Public Class Binders
    Inherits ArrayList
    Implements IBindingList
    Private sLIst As ArrayList
    Public ErrorString As String
    Public ErrorCode As Int32

    Public Sub New()
        MyBase.New()
        ErrorString = ""
        ErrorCode = 0
    End Sub

    Public Sub New(ByVal mList As ArrayList)
        MyBase.new()
        sLIst = mList
        ErrorString = ""
        ErrorCode = 0
    End Sub

    Public Function GetList() As ArrayList
        Return sLIst
    End Function

#Region "ArrayList Overrides"

    Public Overrides Function Add(ByVal value As Object) As Integer
        Dim index As Integer = MyBase.Add(value)
        RaiseEvent IBindingList_ListChanged(Me, New ListChangedEventArgs(ListChangedType.ItemAdded, index))
    End Function

    Public Overrides Sub Clear()
        MyBase.Clear()
        RaiseEvent IBindingList_ListChanged(Me, New ListChangedEventArgs(ListChangedType.Reset, 0))
    End Sub

    Default Public Overrides Property Item(ByVal index As Integer) As Object
        Get
            If index < 0 Or index >= MyBase.Count Then
                Throw New ArgumentOutOfRangeException
            End If
            Return MyBase.Item(index)
        End Get
        Set(ByVal Value As Object)
            If index < 0 Or index >= MyBase.Count Then
                Throw New ArgumentOutOfRangeException
            End If
            MyBase.Item(index) = Value
            RaiseEvent IBindingList_ListChanged(Me, New ListChangedEventArgs(ListChangedType.ItemChanged, index))
        End Set
    End Property

    Public Overrides Sub Insert(ByVal index As Integer, ByVal value As Object)
        If index < 0 Or index > MyBase.Count Then
            Throw New ArgumentOutOfRangeException
        End If
        MyBase.Insert(index, value)
        RaiseEvent IBindingList_ListChanged(Me, New ListChangedEventArgs(ListChangedType.ItemAdded, index))
    End Sub

    Public Overrides Sub Remove(ByVal value As Object)
        Dim index As Integer = MyBase.IndexOf(value)
        If index < 0 Then
            Throw New ArgumentException
        End If
        MyBase.RemoveAt(index)
        RaiseEvent IBindingList_ListChanged(Me, New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
    End Sub

    Public Overrides Sub RemoveAt(ByVal index As Integer)
        If index < 0 Or index >= MyBase.Count Then
            Throw New ArgumentOutOfRangeException
        End If
        MyBase.RemoveAt(index)
        RaiseEvent IBindingList_ListChanged(Me, New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
    End Sub
#End Region

#Region "IBindingList"

    ReadOnly Property IBindingList_AllowEdit() As Boolean Implements IBindingList.AllowEdit
        Get
            Return False
        End Get
    End Property
    ReadOnly Property IBindingList_AllowNew() As Boolean Implements IBindingList.AllowNew
        Get
            Return False
        End Get
    End Property
    ReadOnly Property IBindingList_AllowRemove() As Boolean Implements IBindingList.AllowRemove
        Get
            Return False
        End Get
    End Property
    ReadOnly Property IBindingList_SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
        Get
            Return True
        End Get
    End Property
    ReadOnly Property IBindingList_SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
        Get
            Return False
        End Get
    End Property
    ReadOnly Property IBindingList_SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
        Get
            Return False
        End Get
    End Property
    ReadOnly Property IBindingList_IsSorted() As Boolean Implements IBindingList.IsSorted
        Get
            Return False
        End Get
    End Property
    ReadOnly Property IBindingList_SortDirection() As ListSortDirection Implements IBindingList.SortDirection
        Get
            Throw New NotSupportedException
        End Get
    End Property
    ReadOnly Property IBindingList_SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Sub IBindingList_AddIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.AddIndex
        Throw New NotSupportedException
    End Sub

    Function IBindingList_AddNew() As Object Implements IBindingList.AddNew
        Throw New NotSupportedException
    End Function

    Sub IBindingList_ApplySort(ByVal [property] As PropertyDescriptor, ByVal [direction] As ListSortDirection) Implements IBindingList.ApplySort
        Throw New NotSupportedException
    End Sub

    Function IBindingList_Find(ByVal [property] As PropertyDescriptor, ByVal [key] As Object) As Integer Implements IBindingList.Find
        Throw New NotSupportedException
    End Function

    Sub IBindingList_RemoveIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.RemoveIndex
        Throw New NotSupportedException
    End Sub

    Sub IBindingList_RemoveSort() Implements IBindingList.RemoveSort
        Throw New NotSupportedException
    End Sub

    Public Event IBindingList_ListChanged As ListChangedEventHandler Implements IBindingList.ListChanged

#End Region
End Class
