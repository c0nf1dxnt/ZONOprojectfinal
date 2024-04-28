﻿namespace ZONOproject.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель рекомендации в коллекции
    /// </summary>
    public class RecommendationInCollection
    {
        public Guid RecommendationInCollectionsID { get; set; }

        public Guid CollectionID { get; set; }

        public Guid RecommendationID { get; set; }
    }
}