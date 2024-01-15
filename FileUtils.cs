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
            QuizCategory categoryQuestions = new QuizCategory();

            XmlSerializer serializer = new XmlSerializer(typeof(QuizCategory));

            using (FileStream file = File.OpenRead(fileToPlay))
            {
                categoryQuestions = serializer.Deserialize(file) as QuizCategory;
            }
            return categoryQuestions;
        }
    }
}
