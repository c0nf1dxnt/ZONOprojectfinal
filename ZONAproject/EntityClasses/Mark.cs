﻿namespace ZONOproject.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель цвета
    /// </summary>
    public class Mark
    {
        public Guid MarkID { get; set; }

        public int MarkValue { get; set; }

        public Guid ID { get; set; }

        public Guid RecommendationID { get; set; }
    }
}