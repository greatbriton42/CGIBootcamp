﻿// <copyright file="BasePagedList.cs" company="Computer Technology Solutions, Inc.">
// Copyright (c) 2010 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// </copyright>
// <author>jvance</author>
// <date>9/11/2010 6:49:04 PM</date>
// <productName></productName>
namespace ABC.Venture.Common.GridEx
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Sort direction used for server side sorting as well as UI automating.
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// Ascending sorting.
        /// </summary>
        Ascending,

        /// <summary>
        /// Descending sorting.
        /// </summary>
        Descending
    }

    /// <summary>
    /// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
    /// </summary>
    /// <remarks>
    /// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
    /// </remarks>
    /// <typeparam name="T">The type of object the collection should contain.</typeparam>
    /// <seealso cref="IGrid{T}"/>
    /// <seealso cref="List{T}"/>
    public abstract class BaseGrid<T> : List<T>, IGrid<T>
    {
        /// <summary>
        /// Page and sort critria container.
        /// </summary>
        public PageSortCriteria Criteria { get; set; }

        /// <summary>
        /// Constructor to instantiate object with specific page index and number of item to be returned for the page.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pageSize"></param>
        internal protected BaseGrid(int index, int pageSize)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", index, "PageIndex cannot be below 0.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");

            // set source to blank list if superset is null to prevent exceptions
            PageSize = pageSize;
            PageIndex = index;
        }

        /// <summary>
        /// Initializes a new instance of a type deriving from <see cref="BaseGrid{T}"/> and sets properties needed to calculate position and size data on the subset and superset.
        /// </summary>
        /// <param name="index">The index of the subset of objects contained by this instance.</param>
        /// <param name="pageSize">The maximum size of any individual subset.</param>
        /// <param name="totalItemCount">The size of the superset.</param>
        internal protected BaseGrid(int index, int pageSize, int totalItemCount)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", index, "PageIndex cannot be below 0.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");

            // set source to blank list if superset is null to prevent exceptions
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            PageIndex = index;
            if (TotalItemCount > 0)
                PageCount = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
            else
                PageCount = 0;


        }

        /// <summary>
        /// Set number of pages from total item count.
        /// </summary>
        /// <param name="totalItemCount">data used to calculate.</param>
        protected void Update(int totalItemCount)
        {
            TotalItemCount = totalItemCount;
            if (TotalItemCount > 0)
                PageCount = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
            else
                PageCount = 0;
        }

        #region IPagedList<T> Members

        /// <summary>
        /// Total number of subsets within the superset.
        /// </summary>
        /// <value>
        /// Total number of subsets within the superset.
        /// </value>
        public int PageCount { get; protected set; }

        /// <summary>
        /// Total number of objects contained within the superset.
        /// </summary>
        /// <value>
        /// Total number of objects contained within the superset.
        /// </value>
        public int TotalItemCount { get; protected set; }

        /// <summary>
        /// Zero-based index of this subset within the superset.
        /// </summary>
        /// <value>
        /// Zero-based index of this subset within the superset.
        /// </value>
        public int PageIndex { get; protected set; }

        /// <summary>
        /// One-based index of this subset within the superset.
        /// </summary>
        /// <value>
        /// One-based index of this subset within the superset.
        /// </value>
        public int PageNumber
        {
            get { return PageIndex; }
        }

        /// <summary>
        /// Maximum size any individual subset.
        /// </summary>
        /// <value>
        /// Maximum size any individual subset.
        /// </value>
        public int PageSize { get; protected set; }

        /// <summary>
        /// Returns true if this is NOT the first subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is NOT the first subset within the superset.
        /// </value>
        public bool HasPreviousPage
        {
            get { return PageIndex > 1; }
        }

        /// <summary>
        /// Returns true if this is NOT the last subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is NOT the last subset within the superset.
        /// </value>
        public bool HasNextPage
        {
            get { return PageIndex < (PageCount); }
        }

        /// <summary>
        /// Returns true if this is the first subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is the first subset within the superset.
        /// </value>
        public bool IsFirstPage
        {
            get { return PageIndex <= 1; }
        }

        /// <summary>
        /// Returns true if this is the last subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is the last subset within the superset.
        /// </value>
        public bool IsLastPage
        {
            get { return PageIndex >= (PageCount); }
        }

        #endregion
    }
}