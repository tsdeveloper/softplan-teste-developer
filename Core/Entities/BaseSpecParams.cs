﻿namespace Core.Entities
{
    public class BaseSpecParams : BaseEntity
    {
        private const int MaxPageSize = 50;
        private string _search;
        public int PageIndex { get; set; } = 1;
        private int _pageSize { get; set; } = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string Sort { get; set; }

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}