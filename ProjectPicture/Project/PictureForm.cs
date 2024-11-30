using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace risunok
{
    public partial class PictureForm : Form
    {
        public PictureForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем объект графики для рисования на форме
            var g = CreateGraphics();
            g.Clear(this.BackColor); // Очищаем форму перед новым рисованием

            // Рисуем кузов автобуса
            var bodyBrush = new SolidBrush(Color.LightBlue); // Твердая заливка
            g.FillRectangle(bodyBrush, 100, 200, 400, 100);

            // Рисуем крышу автобуса (прямоугольник)
            g.FillRectangle(bodyBrush, 100, 170, 400, 30);

            // Рисуем окна автобуса
            var windowBrush = new SolidBrush(Color.White); // Твердая заливка
            g.FillRectangle(windowBrush, 130, 220, 80, 40); // Левое окно
            g.FillRectangle(windowBrush, 230, 220, 80, 40); // Среднее окно
            g.FillRectangle(windowBrush, 330, 220, 80, 40); // Правое окно

            // Рисуем колеса
            var wheelBrush = new SolidBrush(Color.Black); // Твердая заливка
            g.FillEllipse(wheelBrush, 120, 290, 50, 50); // Левое колесо
            g.FillEllipse(wheelBrush, 320, 290, 50, 50); // Правое колесо

            // Рисуем диски колес
            var rimBrush = new SolidBrush(Color.Gray); // Твердая заливка
            g.FillEllipse(rimBrush, 130, 300, 20, 20); // Левый диск
            g.FillEllipse(rimBrush, 330, 300, 20, 20); // Правый диск

            // Рисуем градиентные окна
            var gradientBrush = new LinearGradientBrush(new Rectangle(130, 220, 80, 40), Color.LightSkyBlue, Color.Blue, 45f);
            g.FillRectangle(gradientBrush, 130, 220, 80, 40); // Градиент на левом окне

            // Рисуем переднюю часть автобуса
            var frontBrush = new SolidBrush(Color.DarkRed);
            g.FillRectangle(frontBrush, 95, 210, 5, 70); // Передний бампер
            g.FillRectangle(frontBrush, 495, 210, 5, 70); // Задний бампер

            // Рисуем дорожные линии (прямые линии)
            using (var pen = new Pen(Color.Yellow, 2))
            {
                g.DrawLine(pen, 50, 400, 600, 400); // Дорожная линия
            }

            // Рисуем дополнительные детали (трава под автобусом)
            using (var grassBrush = new SolidBrush(Color.Green))
            {
                g.FillRectangle(grassBrush, 0, 350, this.ClientSize.Width, 50); // Трава
            }


            // Освобождаем ресурсы
            bodyBrush.Dispose();
            windowBrush.Dispose();
            wheelBrush.Dispose();
            rimBrush.Dispose();
            gradientBrush.Dispose();
            frontBrush.Dispose();
        }
    }
}