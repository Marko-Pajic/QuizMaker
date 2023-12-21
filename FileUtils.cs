using QuizMaker.Enumerations;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class FileUtils
    {
        /// <summary>
        /// searches for specific xml file
        /// </summary>
        /// <returns>depending on file existence an appropriate enum</returns>
        public static QuizState GetMenuOption()
        {
            bool fileExists = Directory.Exists(Constant.DIRECTORY_FOLDER);
            if (fileExists != false)
            {
                return UI.GetOptionPreferences();
            }
            else
            {
                return QuizState.Build;
            }
        }

        public static void SerializeCategoryToFile(QuizCategory questionContainer, List<Question> categoryQuestions)
        {
            string directoryPath = Constant.DIRECTORY_FOLDER;
            string fileName = $@"{questionContainer.Name}.xml";
            string filePath = Path.Combine(directoryPath, fileName);

            Directory.CreateDirectory(directoryPath);

            XmlSerializer serializer = new XmlSerializer(typeof(QuizCategory/*List<Question>*/));
            using (FileStream file = File.Create(filePath))
            {
                serializer.Serialize(file, questionContainer);
            }
        }

        public static string[] GetCategorySelection()
        {
            string filePath = Constant.DIRECTORY_FOLDER;
            string[] fileEntries = Directory.GetFiles(filePath);
            return fileEntries;
        }

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
