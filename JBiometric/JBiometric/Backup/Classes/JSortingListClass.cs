using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AttendanceKeeper.Classes
{
    class JSortingListClass<T> : BindingList<T>
    {
            private bool _isSorted;
            private ListSortDirection _sortDirection;
            private PropertyDescriptor _sortProperty;

            //This override shows the binded object, that our list supports sorting
            protected override bool SupportsSortingCore
            {
                get { return true; }
            }

            //And that it can sort bi-directional
            protected override ListSortDirection SortDirectionCore
            {
                get { return _sortDirection; }
            }

            //And that it can sort by T typed object's properties
            protected override PropertyDescriptor SortPropertyCore
            {

                get { return _sortProperty; }
            }

            //This is the method, what gets called when the sort event occurs in the bound object
            protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
            {
                List<T> items = this.Items as List<T>;

                if (items != null)
                {
                    PropertyComparer<T> pc = new PropertyComparer<T>(prop.Name, direction);
                    items.Sort(pc);
                    _isSorted = true;
                    _sortDirection = direction;
                    _sortProperty = prop;
                }
                else
                {
                    _isSorted = false;
                }
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }

            //This shows if our list is already sorted or not
            protected override bool IsSortedCore
            {
                get { return _isSorted; }
            }

            //Removing the sort
            protected override void RemoveSortCore()
            {
                _isSorted = false;
            }

            public JSortingListClass(IList<T> list)
                : base(list)
            {
            }
    }
}
