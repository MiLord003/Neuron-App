using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Neuron
{
    public class Button : Control // модификатор доступа : родительский класс
    {
        private StringFormat SF = new StringFormat();

        private bool MouseEntered = false;
        private bool MousePressed = false;

        public Button() // конструктор для нашего класса
        {
            // оптимизация объекта и уменьшение мерцания
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true; // при изменении размера объекта - перерисовывать его

            Size = new Size(100, 30); // изначальный размер кнопки

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs e) // перерисовывет объект
        {
            base.OnPaint(e); // базовый метод, который вызывает других

            Graphics graph = e.Graphics; // для рисования
            graph.SmoothingMode = SmoothingMode.HighQuality; // качество визуализации

            graph.Clear(Parent.BackColor); // очистка поверхности и залитие нужным цветом

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1); // реализация прямоугольника

            graph.DrawRectangle(new Pen(BackColor), rect); // рисование карандашом
            graph.FillRectangle(new SolidBrush(BackColor), rect);

            if (MouseEntered) // проверка при отвода мыши
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(60, Color.White)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.White)), rect);
            }

            if (MousePressed) // проверка наведения мыши
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(30, Color.Black)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), rect);
            }

            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF); // рисует текст на кнопке
        }

        protected override void OnMouseEnter(EventArgs e) // вызывается при наведении мыши на компонент
        {
            base.OnMouseEnter(e);

            MouseEntered = true;

            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e) // вызывается, когда курсор выходит за границы компонента
        {
            base.OnMouseLeave(e);

            MouseEntered = false;

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e) // вызывается при нажатии на компонент мышью
        {
            base.OnMouseDown(e);

            MousePressed = true;

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e) // вызывается при отжатии компонента мышью
        {
            base.OnMouseUp(e);

            MousePressed = false;

            Invalidate();
        }
    }
}