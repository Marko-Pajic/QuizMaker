using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class FileUtils
    {
        public static QuizState GetMenuOption()
        {
            string directoryPath = @"xml.files";
            bool fileExists = Directory.Exists(directoryPath);
            if (fileExists != false)
            {
                return UIMethod.GetOptionPreferences();
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

        public static string GetCategorySelection()
        {
            UIMethod.ShowCategoryInquiry();

            string filePath = Constant.DIRECTORY_FOLDER;
            string[] fileEntries = Directory.GetFiles(filePath);
            string fileEntry;

            for (int i = 0; i < fileEntries.Length; i++)
            {
                fileEntry = fileEntries[i];
                UIMethod.ShowAnswerList(i, fileEntry);
            }

            int numOfChosenCategory = int.Parse(Console.ReadLine());
            string fileToPlay = fileEntries[numOfChosenCategory - 1];
            return fileToPlay;
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
