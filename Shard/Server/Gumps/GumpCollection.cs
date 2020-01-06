/***************************************************************************
 *                             GumpCollection.cs
 *                            -------------------
 *   begin                : May 1, 2002
 *   copyright            : (C) The RunUO Software Team
 *   email                : info@runuo.com
 *
 *   $Id: GumpCollection.cs,v 1.5 2011/02/24 18:32:42 luket Exp $
 *   $Author: luket $
 *   $Date: 2011/02/24 18:32:42 $
 *
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Gumps
{
    using System;
    using System.Collections;
    
    
    /// <summary>
    /// Strongly typed collection of Server.Gumps.Gump.
    /// </summary>
    public class GumpCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GumpCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Gumps.Gump at a specific position in the GumpCollection.
        /// </summary>
        public Server.Gumps.Gump this[int index]
        {
            get
            {
                return ((Server.Gumps.Gump)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
        }
        
        /// <summary>
        /// Append a Server.Gumps.Gump entry to this collection.
        /// </summary>
        /// <param name="value">Server.Gumps.Gump instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Gumps.Gump value)
        {
            return this.List.Add(value);
        }
        
        /// <summary>
        /// Determines whether a specified Server.Gumps.Gump instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Gumps.Gump instance to search for.</param>
        /// <returns>True if the Server.Gumps.Gump instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Gumps.Gump value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Gumps.Gump instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Gumps.Gump instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Gumps.Gump instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Gumps.Gump value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Gumps.Gump instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Gumps.Gump instance to remove.</param>
        public void Remove(Server.Gumps.Gump value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Gumps.Gump instance.
        /// </summary>
        /// <returns>An Server.Gumps.Gump's enumerator.</returns>
        public new GumpCollectionEnumerator GetEnumerator()
        {
            return new GumpCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Gumps.Gump instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Gumps.Gump instance to insert.</param>
        public void Insert(int index, Server.Gumps.Gump value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Gumps.Gump.
        /// </summary>
        public class GumpCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Gumps.Gump _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private GumpCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal GumpCollectionEnumerator(GumpCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Gumps.Gump object in the enumerated GumpCollection currently indexed by this instance.
            /// </summary>
            public Server.Gumps.Gump Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}
