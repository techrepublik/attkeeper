using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace AttendanceKeeper.Classes
{
    class PropertyComparer<T> : IComparer<T>
    {
        private PropertyInfo _property;
        private ListSortDirection _sortDirection;

        public PropertyComparer(string sortProperty, ListSortDirection sortDirection)
        {
            _property = typeof(T).GetProperty(sortProperty);
            this._sortDirection = sortDirection;
        }

        public int Compare(T x, T y)
        {
            object valueX = _property.GetValue(x, null);
            object valueY = _property.GetValue(y, null);

            if (_sortDirection == ListSortDirection.Ascending) return Comparer.Default.Compare(valueX, valueY);

            return Comparer.Default.Compare(valueY, valueX);
        }
    }
}
