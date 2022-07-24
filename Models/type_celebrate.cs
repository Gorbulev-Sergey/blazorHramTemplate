using System.ComponentModel;

namespace blazorHramTemplate2.Models
{
    public enum тип_праздника
    {
        [Description("")]
        пусто = 0,
        [Description("жирный")]
        жирный = 1,
        [Description("курсив")]
        курсив = 2,
        [Description("жирный заглавный")]
        жирный_заглавный = 3,

        [Description("синий")]
        primary = 4,
        [Description("зелёный")]
        success = 5,
        [Description("красный")]
        danger = 6,
        [Description("жёлтый")]
        warning = 7,
        [Description("голубой")]
        info = 8,
        [Description("светлый")]
        light = 9,
        [Description("серый")]
        secondary = 10,

        [Description("синий курсив")]
        primary_cursive = 11,
        [Description("зелёный курсив")]
        success_cursive = 12,
        [Description("красный курсив")]
        danger_cursive = 13,
        [Description("жёлтый курсив")]
        warning_cursive = 14,
        [Description("голубой курсив")]
        info_cursive = 15,
        [Description("светлый курсив")]
        light_cursive = 16,
        [Description("серый курсив")]
        secondary_cursive = 17,

        [Description("синий жирный")]
        primary_bold = 18,
        [Description("зелёный жирный")]
        success_bold = 19,
        [Description("красный жирный")]
        danger_bold = 20,
        [Description("жёлтый жирный")]
        warning_bold = 21,
        [Description("голубой жирный")]
        info_bold = 22,
        [Description("светлый жирный")]
        light_bold = 23,
        [Description("серый жирный")]
        secondary_bold = 24,

        [Description("синий жирный заглавный")]
        primary_bold_up = 25,
        [Description("зелёный жирный заглавный")]
        success_bold_up = 26,
        [Description("красный жирный заглавный")]
        danger_bold_up = 27,
        [Description("жёлтый жирный заглавный")]
        warning_bold_up = 28,
        [Description("голубой жирный заглавный")]
        info_bold_up = 29,
        [Description("светлый жирный заглавный")]
        light_bold_up = 30,
        [Description("серый жирный заглавный")]
        secondary_bold_up = 31
    }
}
