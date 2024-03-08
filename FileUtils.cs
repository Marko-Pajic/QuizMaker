using QuizMaker.Enumerations;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class FileUtils
    {
        /// <summary>
        /// searches for specific xml file
        /// </summary>
        /// <returns>enum depending on file existence</returns>
        public static QuizState GetMenuOption()
        {
            bool fileExists = Directory.Exists(Constant.DIRECTORY_FOLDER);
            if (fileExists)
            {
                return UI.GetOptionPreferences();
            }
            else
            {
                return QuizState.Build;
            }
        }

        /// <summary>
        /// creates a new folder with new files populating them by serialization
        /// </summary>
        /// <param name="questionContainer">object</param>
        public static void SerializeCategoryToFile(QuizCategory questionContainer)
        {
            string directoryPath = Constant.DIRECTORY_FOLDER;
            string fileName = $@"{questionContainer.Name}.xml";
            string filePath = Path.Combine(directoryPath, fileName);

            Directory.CreateDirectory(directoryPath);

            XmlSerializer serializer = new XmlSerializer(typeof(QuizCategory));
            using (FileStream file = File.Create(filePath))
            {
                serializer.Serialize(file, questionContainer);
            }
        }
        /// <summary>
        /// 1. creates list of objects
        /// 2. choose a object out of list
        /// 3. extracts the chosen objects
        /// </summary>
        /// <param name="quizSection">new object</param>
        /// <returns>new object</returns>
        public static QuizCategory GetSectionToModify(QuizCategory quizSection)
        {
            string[] fileEntires = GetCategorySelection();
            string fileToPlay = UI.GetSelectedFileName(fileEntires);
            quizSection = DeserializeFileToCategory(fileToPlay);

            return quizSection;
        }
        /// <summary>
        /// uses GetFiles method to populate the array
        /// </summary>
        /// <returns>array of files</returns>
        public static string[] GetCategorySelection()
        {
            string filePath = Constant.DIRECTORY_FOLDER;
            string[] fileEntries = Directory.GetFiles(filePath);
            return fileEntries;
        }

        /// <summary>
        /// creates new object and populizes it by deserialization of chosen file
        /// </summary>
        /// <param name="fileToPlay">file to deserialize</param>
        /// <returns>object</returns>
        public static QuizCategory DeserializeFileToCategory(string fileToPlay)
        {
            QuizCategory quizChapter = new QuizCategory();
            XmlSerializer serializer = new XmlSerializer(typeof(QuizCategory));

            using (FileStream file = File.OpenRead(fileToPlay))
            {
                quizChapter = serializer.Deserialize(file) as QuizCategory;
            }
            return quizChapter;
        }
        /// <summary>
        /// serializing object to file
        /// </summary>
        /// <param name="quizChapter">object</param>
        /// <param name="filePath">filepath</param>
        public static void SerializeModifiedCategoryToFile(QuizCategory quizChapter, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(QuizCategory));

            using (FileStream file = File.Create(filePath))
            {
                serializer.Serialize(file, quizChapter);
            }
        }
        /// <summary>
        /// 1.creates a new filepath for the manipulated object
        /// 2. old file path gets deleted
        /// </summary>
        /// <param name="quizChapter">object</param>
        /// <param name="oldFilePath">oldfilepath</param>
        /// <returns></returns>
        public static string UpdateAndSerializeNewCategoryName(QuizCategory quizChapter, string oldFilePath)
        {
            string directoryPath = Constant.DIRECTORY_FOLDER;
            string newFileName = $"{quizChapter.Name}.xml";
            string newFilePath = Path.Combine(directoryPath, newFileName);

            XmlSerializer serializer = new XmlSerializer(typeof(QuizCategory));

            using (FileStream file = File.Create(newFilePath))
            {
                serializer.Serialize(file, quizChapter);
            }

            File.Delete(oldFilePath);

            return newFilePath;
        }

    }
}
