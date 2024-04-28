﻿using ZONOproject.EntityClasses;
using System.Resources;
using NLog;

namespace ZONOproject.Database
{
    /// <summary>
    /// Класс взаимодействия с базой данных
    /// </summary>
    public static class DatabaseInteraction
    {
        #region Поля
        static ResourceManager languageResources = null!;
        static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Методы
        /// <summary>
        /// Метод для проверки существования учетной записи в базе данных
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        public static bool CheckLoginData(string login, string password)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке входа");

                    var User = database.Users.Where(user => user.Login == login).FirstOrDefault();

                    if (User != null)
                    {
                        if (User.Password == DataEncryption.HashingData(password))
                        {
                            logger.Debug($"Пользователь с id {User.ID} вошел в аккаунт");

                            Program.SetLoginInformation(true, User.ID);
                            return true;
                        }
                    }
                    logger.Debug("Пользователь не вошел в аккаунт, т.к. введен неверный логин или пароль");

                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex, 
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        /// <summary>
        /// Метод для регистрации нового пользователя и внесения его данных в базу данных
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        public static bool RegisterNewUser(string login, string password)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке регистрации");

                    if (database.Users.Any(user => user.Login == login))
                    {
                        logger.Info("Пользователь не зарегистрирован, т.к. введенный логин уже " +
                            "существует в базе данных");

                        return false;
                    }

                    var newUser = new User
                    {
                        Login = login,
                        Password = DataEncryption.HashingData(password)
                    };

                    database.Users.Add(newUser);
                    database.SaveChanges();

                    logger.Info($"Пользователь с id {newUser.ID} успешно зарегистрирован");

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        /// <summary>
        /// Метод поиска пользователя по ID
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        public static User FindUser(Guid userID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при поиске пользователя по id");

                    var user = database.Users.Find(userID);

                    return user != null ? user : null!;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null!;
            }
        }

        /// <summary>
        /// Метод проверки является ли товар избранным пользователя
        /// </summary>
        /// <param name="RecommendationID">ID товара</param>
        /// <param name="ID">ID пользователя</param>
        public static bool IsProductInFavorites(Guid RecommendationID, Guid ID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при поиске избранных товаров");

                    bool isInFavorites = database.Favorites.Any(favorite =>
                    favorite.RecommendationID == RecommendationID && favorite.ID == ID);

                    return isInFavorites;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        /// <summary>
        /// Метод загрузки подборок пользователя
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        public static string[] LoadUserCollections(Guid userID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при поиске подборок пользователя");

                    string[] userCollections = database.UserCollections.Where(collection => collection.ID == userID)
                        .Select(collection => collection.CollectionName).ToArray();

                    return userCollections;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return Array.Empty<string>();
            }
        }

        /// <summary>
        /// Метод загрузки типов товаров
        /// </summary>
        public static string[] LoadProductTypes()
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при загрузке всех типов товаров");

                    string[] productTypes = database.ProductTypes.AsEnumerable().Select(product => product
                    .ProductTypeName).ToArray();

                    return productTypes;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return Array.Empty<string>();
            }
        }

        /// <summary>
        /// Метод добавления товара в избранное
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        /// <param name="recommendationId">ID товара</param>
        public static void AddToFavorites(Guid userID, Guid recommendationId)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке добавить товар в избранное");

                    var userFavorite = new Favorite
                    {
                        FavoriteID = Guid.NewGuid(),
                        ID = userID,
                        RecommendationID = recommendationId
                    };

                    logger.Debug($"Товар с id {recommendationId} добавлен в избранное " +
                        $"пользователю с id {userID}");

                    database.Favorites.Add(userFavorite);
                    database.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод удаления товара из избранного
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        /// <param name="recommendationId">ID товара</param>
        public static void RemoveFromFavorites(Guid userID, Guid recommendationId)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке удаления товара из избранного");

                    var userFavorite = database.Favorites.Where(favorite => favorite.ID == userID)
                        .Where(favorite => favorite.RecommendationID == recommendationId).FirstOrDefault();

                    if (userFavorite != null) 
                    {
                        logger.Debug($"Товар с id {recommendationId} удален из избранного " +
                        $"пользовател с id {userID}");

                        database.Favorites.Remove(userFavorite);
                        database.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод добавления товара в коллекцию
        /// </summary>
        /// <param name="recommendationID">ID товара</param>
        /// <param name="collectionID">ID коллекции</param>
        public static void AddProductToCollection(Guid recommendationID, Guid collectionID, Guid userID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке добавить товар в подборку");

                    var existingRelation = database.RecommendationInCollections.FirstOrDefault(product => product.RecommendationID
                    == recommendationID && product.CollectionID == collectionID);

                    if (existingRelation != null)
                    {
                        return;
                    }

                    var otherRelations = database.RecommendationInCollections.Where(product => product.RecommendationID
                    == recommendationID && product.CollectionID != collectionID).ToList();

                    if (otherRelations.Any())
                    {
                        foreach (var relation in otherRelations)
                        {
                            database.RecommendationInCollections.Remove(relation);
                        }
                    }

                    var newRelation = new RecommendationInCollection()
                    {
                        RecommendationInCollectionsID = Guid.NewGuid(),
                        RecommendationID = recommendationID,
                        CollectionID = collectionID                    
                    };

                    logger.Debug($"Товар с id {recommendationID} успешно добавлен в подборку с id {collectionID}");

                    database.RecommendationInCollections.Add(newRelation);
                    database.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод добавления новой оценки
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        /// <param name="recommendationID">ID товара</param>
        /// <param name="markValue">Оценка</param>
        public static void AddNewMark(Guid userID, Guid recommendationID, int markValue)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке поставить оценку товару");

                    var relatedMarks = database.Marks.Where(mark => mark.ID == userID && mark.RecommendationID
                    == recommendationID).ToList();
                    if (relatedMarks.Any())
                    {
                        foreach (var mark in relatedMarks)
                        {
                            database.Marks.Remove(mark);
                        }
                    }
                    var newMark = new Mark()
                    {
                        ID = userID,
                        MarkValue = markValue,
                        RecommendationID = recommendationID,
                        MarkID = Guid.NewGuid()
                    };

                    logger.Debug($"Оценка с id {newMark.ID} успешно добавлен товару с id {recommendationID}");

                    database.Marks.Add(newMark);
                    database.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод рассчёта рейтинга товара
        /// </summary>
        /// <param name="recommendationID">ID товара</param>
        public static float CountProductRating(Guid recommendationID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при загрузке рейтинга товара");

                    var listOfMarks = database.Marks.Where(mark => mark.RecommendationID == recommendationID).ToList();
                    var numberOfMarks = listOfMarks.Count();
                    var sumOfMarks = 0;

                    if (numberOfMarks.Equals(1) || numberOfMarks.Equals(0))
                    {
                        return sumOfMarks;
                    }

                    foreach (var mark in listOfMarks)
                    {
                        sumOfMarks += mark.MarkValue;
                    }

                    double rating = (double)sumOfMarks / numberOfMarks;

                    logger.Debug($"Оценка товара с id {recommendationID} успешно загружена");

                    return (float)Math.Round(rating, 2);
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }
        }

        /// <summary>
        /// Метод проверки понравился ли товар пользователю
        /// </summary>
        /// <param name="RecommendationID">ID товара</param>
        /// <param name="ID">ID пользователя</param>
        public static bool IsProductLiked(Guid RecommendationID, Guid ID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при проверке понравившихся " +
                        "пользователю товаров");

                    bool isInLiked = database.LikedProducts.Any(product =>
                    product.RecommendationID == RecommendationID && product.ID == ID);

                    return isInLiked;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
        #endregion
    }
}