using PryamolineynostWF.Models.Collimator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.DTO.Collimator
{
    public class MeasurementRowModelDTO
    {
        public int Position{ get; set; } // Номер измерений
        public int MeasurementLength{ get; set; } // Длина измерения, мм
        public int? ForwardMinutesHorizontal{ get; set; } // Минуты прямой ход
        public decimal? ForwardSecondsHorizontal{ get; set; } // Секунды прямой ход
        public int? ReverseMinutesHorizontal{ get; set; } // Минуты обратный ход
        public decimal? ReverseSecondsHorizontal{ get; set; } // Секунды обратный ход
        
        //Вертикальная поверхность
        public int? ForwardMinutesVertical{ get; set; } // Минуты прямой ход
        public decimal? ForwardSecondsVertical{ get; set; } // Секунды прямой ход
        public int? ReverseMinutesVertical{ get; set; } // Минуты обратный ход
        public decimal? ReverseSecondsVertical{ get; set; } // Секунды обратный ход

        public decimal? FirstMeanAngleHorizontal{ get; set; }
        public decimal? FirstMeanAngleVertical{ get; set; }
        public decimal? LastPointAngleCoeficentHorizontal{ get; set; }
        public decimal? LastPointAngleCoeficentVertical{ get; set; }

        public int StepSize{ get; set; } // Шаг
        public bool IsReverseStrokeEnabled{ get; set; } // Включен ли учет обратного хода
        public bool IsLastRow{ get; set; }
    }
}
