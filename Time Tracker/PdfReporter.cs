using Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Time_Tracker
{
    class PdfReporter
    {
        public static void GeneratePdfReport(String outputFileName, Project project, Filter<Task> taskFilter) 
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(outputFileName, FileMode.Create));
            doc.Open();

            doc.Add(new Phrase("\nProject \"" + project.Name + "\"\n",
                    new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 36,
                        iTextSharp.text.Font.BOLD,
                        new BaseColor(Color.Black))));

            doc.Add(new Phrase("\nActivity",
                    new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 28,
                        iTextSharp.text.Font.BOLD,
                        new BaseColor(Color.Black))));  

            PdfPTable table = new PdfPTable(new float[] {80f, 20f});
            table.WidthPercentage = 100f;

            PdfPCell taskNameColumnHeader = new PdfPCell(
                new Phrase("Task Name",
                    new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                        iTextSharp.text.Font.BOLD, 
                        new BaseColor(Color.Black))));
            taskNameColumnHeader.BackgroundColor = new BaseColor(Color.LightGray);
            taskNameColumnHeader.Padding = 15;
            table.AddCell(taskNameColumnHeader);

            PdfPCell taskDurationColumnHeader = new PdfPCell(
                new Phrase("Duration",
                    new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                        iTextSharp.text.Font.BOLD,
                        new BaseColor(Color.Black))));
            taskDurationColumnHeader.BackgroundColor = new BaseColor(Color.LightGray);
            taskDurationColumnHeader.Padding = 15;
            taskDurationColumnHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(taskDurationColumnHeader);

            List<Task> tasks = project.GetTasks(taskFilter);
            int totalDuration = 0;
            foreach (Task task in tasks)
            {
                PdfPCell taskNameCell = new PdfPCell(new Phrase(task.Name));
                taskNameCell.Padding = 5;
                taskNameCell.PaddingLeft = 10;
                table.AddCell(taskNameCell);

                PdfPCell durationCell = new PdfPCell(new Phrase(FormatDuration(task.DurationInSeconds)));
                durationCell.Padding = 5;
                durationCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(durationCell);

                totalDuration += task.DurationInSeconds;
            }

            PdfPCell totalFooterColumn = new PdfPCell(
                new Phrase("Total",
                    new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14,
                        iTextSharp.text.Font.BOLD,
                        new BaseColor(Color.Black))));
            totalFooterColumn.Padding = 10;
            totalFooterColumn.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(totalFooterColumn);

            PdfPCell totalValueFooterColumn = new PdfPCell(
                new Phrase(FormatDuration(totalDuration),
                    new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14,
                        iTextSharp.text.Font.BOLD,
                        new BaseColor(Color.Black))));
            totalValueFooterColumn.Padding = 10;
            totalValueFooterColumn.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(totalValueFooterColumn);
            doc.Add(table);

            if (project.Rate > 0) {
                Phrase rateStr = new Phrase("\nRate per hour: " + project.Rate.ToString("C"),
                        new iTextSharp.text.Font(
                            iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18,
                            iTextSharp.text.Font.BOLD,
                            new BaseColor(Color.Black)));
                Paragraph rateParagraph = new Paragraph(rateStr);
                doc.Add(rateParagraph);

                decimal amount = totalDuration * project.Rate / TaskUtil.SECONDS_IN_HOUR;
                Phrase amountStr = new Phrase("Total Amount: " + amount.ToString("C"),
                        new iTextSharp.text.Font(
                            iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 24,
                            iTextSharp.text.Font.BOLD,
                            new BaseColor(Color.Black)));
                Paragraph amountParagraph = new Paragraph(amountStr);
                doc.Add(amountParagraph);
            }           
            doc.Close();
        }

        private static String FormatDuration(int seconds)
        {
            long hours = seconds / TaskUtil.SECONDS_IN_HOUR;
            long minutes = (seconds - hours * TaskUtil.SECONDS_IN_HOUR) / TaskUtil.SECONDS_IN_MINUTE;
            return hours + "h " + minutes + "m";
        }
    }
}
