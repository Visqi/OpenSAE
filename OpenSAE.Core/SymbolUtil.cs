﻿namespace OpenSAE.Core
{
    public static class SymbolUtil
    {
        private static readonly List<Symbol> _symbols;
        private static readonly Dictionary<int, Symbol> _symbolsDict;

        /// <summary>
        /// List of all known symbols
        /// </summary>
        public static IReadOnlyList<Symbol> List => _symbols;

        /// <summary>
        /// Dictionary of symbol id
        /// </summary>
        public static IReadOnlyDictionary<int, Symbol> Dictionary => _symbolsDict;

        static SymbolUtil()
        {
            _symbols = new List<Symbol>()
            {
                new Symbol(1, "A", "Capital letter A", SymbolGroup.BasicLetters),
                new Symbol(2, "B", "Capital letter B", SymbolGroup.BasicLetters),
                new Symbol(3, "C", "Capital letter C", SymbolGroup.BasicLetters),
                new Symbol(4, "D", "Capital letter D", SymbolGroup.BasicLetters),
                new Symbol(5, "E", "Capital letter E", SymbolGroup.BasicLetters),
                new Symbol(6, "F", "Capital letter F", SymbolGroup.BasicLetters),
                new Symbol(7, "G", "Capital letter G", SymbolGroup.BasicLetters),
                new Symbol(8, "H", "Capital letter H", SymbolGroup.BasicLetters),
                new Symbol(9, "I", "Capital letter I", SymbolGroup.BasicLetters),
                new Symbol(10, "J", "Capital letter J", SymbolGroup.BasicLetters),
                new Symbol(11, "K", "Capital letter K", SymbolGroup.BasicLetters),
                new Symbol(12, "L", "Capital letter L", SymbolGroup.BasicLetters),
                new Symbol(13, "M", "Capital letter M", SymbolGroup.BasicLetters),
                new Symbol(14, "N", "Capital letter N", SymbolGroup.BasicLetters),
                new Symbol(15, "O", "Capital letter O", SymbolGroup.BasicLetters),
                new Symbol(16, "P", "Capital letter P", SymbolGroup.BasicLetters),
                new Symbol(17, "Q", "Capital letter Q", SymbolGroup.BasicLetters),
                new Symbol(18, "R", "Capital letter R", SymbolGroup.BasicLetters),
                new Symbol(19, "S", "Capital letter S", SymbolGroup.BasicLetters),
                new Symbol(20, "T", "Capital letter T", SymbolGroup.BasicLetters),
                new Symbol(21, "U", "Capital letter U", SymbolGroup.BasicLetters),
                new Symbol(22, "V", "Capital letter V", SymbolGroup.BasicLetters),
                new Symbol(23, "W", "Capital letter W", SymbolGroup.BasicLetters),
                new Symbol(24, "X", "Capital letter X", SymbolGroup.BasicLetters),
                new Symbol(25, "Y", "Capital letter Y", SymbolGroup.BasicLetters),
                new Symbol(26, "Z", "Capital letter Z", SymbolGroup.BasicLetters),
                new Symbol(27, "a", "Capital letter a", SymbolGroup.BasicLetters),
                new Symbol(28, "b", "Capital letter b", SymbolGroup.BasicLetters),
                new Symbol(29, "c", "Capital letter c", SymbolGroup.BasicLetters),
                new Symbol(30, "d", "Capital letter d", SymbolGroup.BasicLetters),
                new Symbol(31, "e", "Capital letter e", SymbolGroup.BasicLetters),
                new Symbol(32, "f", "Capital letter f", SymbolGroup.BasicLetters),
                new Symbol(33, "g", "Capital letter g", SymbolGroup.BasicLetters),
                new Symbol(34, "h", "Capital letter h", SymbolGroup.BasicLetters),
                new Symbol(35, "i", "Capital letter i", SymbolGroup.BasicLetters),
                new Symbol(36, "j", "Capital letter j", SymbolGroup.BasicLetters),
                new Symbol(37, "k", "Capital letter k", SymbolGroup.BasicLetters),
                new Symbol(38, "l", "Capital letter l", SymbolGroup.BasicLetters),
                new Symbol(39, "m", "Capital letter m", SymbolGroup.BasicLetters),
                new Symbol(40, "n", "Capital letter n", SymbolGroup.BasicLetters),
                new Symbol(41, "o", "Capital letter o", SymbolGroup.BasicLetters),
                new Symbol(42, "p", "Capital letter p", SymbolGroup.BasicLetters),
                new Symbol(43, "q", "Capital letter q", SymbolGroup.BasicLetters),
                new Symbol(44, "r", "Capital letter r", SymbolGroup.BasicLetters),
                new Symbol(45, "s", "Capital letter s", SymbolGroup.BasicLetters),
                new Symbol(46, "t", "Capital letter t", SymbolGroup.BasicLetters),
                new Symbol(47, "u", "Capital letter u", SymbolGroup.BasicLetters),
                new Symbol(48, "v", "Capital letter v", SymbolGroup.BasicLetters),
                new Symbol(49, "w", "Capital letter w", SymbolGroup.BasicLetters),
                new Symbol(50, "x", "Capital letter x", SymbolGroup.BasicLetters),
                new Symbol(51, "y", "Capital letter y", SymbolGroup.BasicLetters),
                new Symbol(52, "z", "Capital letter z", SymbolGroup.BasicLetters),

                new Symbol(53, "0", "Number 0", SymbolGroup.Numbers),
                new Symbol(54, "1", "Number 1", SymbolGroup.Numbers),
                new Symbol(55, "2", "Number 2", SymbolGroup.Numbers),
                new Symbol(56, "3", "Number 3", SymbolGroup.Numbers),
                new Symbol(57, "4", "Number 4", SymbolGroup.Numbers),
                new Symbol(58, "5", "Number 5", SymbolGroup.Numbers),
                new Symbol(59, "6", "Number 6", SymbolGroup.Numbers),
                new Symbol(60, "7", "Number 7", SymbolGroup.Numbers),
                new Symbol(61, "8", "Number 8", SymbolGroup.Numbers),
                new Symbol(62, "9", "Number 9", SymbolGroup.Numbers),

                new Symbol(63, ",", "Comma", SymbolGroup.Punctuation),
                new Symbol(64, ".", "Period", SymbolGroup.Punctuation),
                new Symbol(65, "!", "Exclamation point", SymbolGroup.Punctuation),
                new Symbol(67, "@", "At symbol", SymbolGroup.Punctuation),
                new Symbol(68, "&", "Ampersand", SymbolGroup.Punctuation),
                new Symbol(69, "%", "Percentage symbol", SymbolGroup.Punctuation),
                new Symbol(70, "#", "Hashtag", SymbolGroup.Punctuation),
                new Symbol(71, "¥", "Yen symbol", SymbolGroup.Punctuation),
                new Symbol(72, "$", "Dollar symbol", SymbolGroup.Punctuation),
                new Symbol(73, "~", "Tilde", SymbolGroup.Punctuation),
                new Symbol(74, "*", "Star symbol", SymbolGroup.Punctuation),
                new Symbol(75, "\\", "Backslash", SymbolGroup.Punctuation),
                new Symbol(76, "/", "Forward slash", SymbolGroup.Punctuation),
                new Symbol(77, "(", "Open parentheses", SymbolGroup.Punctuation),
                new Symbol(78, ")", "Close parentheses", SymbolGroup.Punctuation),
                new Symbol(79, "<", "Less-than sign", SymbolGroup.Punctuation),
                new Symbol(80, ">", "Greater-than sign", SymbolGroup.Punctuation),
                new Symbol(81, "A*", "Sherif capital A", SymbolGroup.SpecialLetters),
                new Symbol(82, "B*", "Sherif capital B", SymbolGroup.SpecialLetters),
                new Symbol(83, "C*", "Sherif capital C", SymbolGroup.SpecialLetters),
                new Symbol(84, "D*", "Sherif capital D", SymbolGroup.SpecialLetters),
                new Symbol(85, "E*", "Sherif capital E", SymbolGroup.SpecialLetters),
                new Symbol(86, "F*", "Sherif capital F", SymbolGroup.SpecialLetters),

                new Symbol(161, "A^", "Eastern style capital A", SymbolGroup.SpecialLetters),
                new Symbol(162, "B^", "Eastern style capital B", SymbolGroup.SpecialLetters),
                new Symbol(163, "C^", "Eastern style capital C", SymbolGroup.SpecialLetters),
                new Symbol(164, "D^", "Eastern style capital D", SymbolGroup.SpecialLetters),
                new Symbol(165, "E^", "Eastern style capital E", SymbolGroup.SpecialLetters),
                new Symbol(166, "F^", "Eastern style capital F", SymbolGroup.SpecialLetters),

                new Symbol(241, "Circle", "Filled circle", SymbolGroup.FilledSymbols),
                new Symbol(242, "Triangle", "Filled equilateral triangle", SymbolGroup.FilledSymbols),
                new Symbol(243, "Square", "Filled square", SymbolGroup.FilledSymbols),
                new Symbol(244, "Pentagon", "Filled pentagon", SymbolGroup.FilledSymbols),
                new Symbol(245, "Hexagon", "Filled hexagon", SymbolGroup.FilledSymbols),
                new Symbol(246, "Octagon", "Filled regular octagon", SymbolGroup.FilledSymbols),
                new Symbol(247, "Octagon2", "Filled octagon", SymbolGroup.FilledSymbols),
                new Symbol(248, "Triangle2", "Filled right angle triangle", SymbolGroup.FilledSymbols),
                new Symbol(249, "Quarter circle", "Filled quarter circle", SymbolGroup.FilledSymbols),
                new Symbol(250, "Rounded triangle", "Filled rounded equilateral triangle", SymbolGroup.FilledSymbols),
                new Symbol(251, "Rounded square", "Filled rounded square", SymbolGroup.FilledSymbols),
                new Symbol(252, "5-point star", "Filled five point star", SymbolGroup.FilledSymbols),
                new Symbol(253, "♠", "Filled spade symbol", SymbolGroup.FilledSymbols),
                new Symbol(254, "♣", "Filled club symbol", SymbolGroup.FilledSymbols),
                new Symbol(255, "♥", "Filled heart", SymbolGroup.FilledSymbols),
                new Symbol(256, "♦", "Filled diamond symbol", SymbolGroup.FilledSymbols),
                new Symbol(257, "Cresent moon", "Filled cresent moon", SymbolGroup.FilledSymbols),
                new Symbol(258, "Gem", "Filled gem symbol (SG)", SymbolGroup.FilledSymbols),
                new Symbol(259, "Drop", "Filled drop symbol", SymbolGroup.FilledSymbols),
                new Symbol(260, "Half circle", "Filled half circle", SymbolGroup.FilledSymbols),
                new Symbol(261, "Astroid", "Filled astroid shape", SymbolGroup.FilledSymbols),
                new Symbol(262, "Capsule", "Filled stadium/capsule shape", SymbolGroup.FilledSymbols),
                new Symbol(263, "Kidney", "Filled kidney shape", SymbolGroup.FilledSymbols),
                new Symbol(264, "Splotch", "Filled splotch shape", SymbolGroup.FilledSymbols),
                new Symbol(265, "12-point star", "Filled 12 point star", SymbolGroup.FilledSymbols),
                new Symbol(266, "Concave triangle", "Filled triangle with 1 concave side", SymbolGroup.FilledSymbols),
                new Symbol(267, "Deltoid", "Filled deltoid triangle", SymbolGroup.FilledSymbols),
                new Symbol(268, "Tear", "Filled tear", SymbolGroup.FilledSymbols),
                new Symbol(269, "Badge", "Filled badge", SymbolGroup.FilledSymbols),
                new Symbol(270, "Badge2", "Filled angular badge", SymbolGroup.FilledSymbols),
                new Symbol(271, "Donut", "Filled donut shape", SymbolGroup.FilledSymbols),

                new Symbol(272, "Outlined circle", SymbolGroup.OutlinedSymbols),
                new Symbol(273, "Outlined triangle", "Outlined equilateral triangle", SymbolGroup.OutlinedSymbols),
                new Symbol(274, "Outlined square", SymbolGroup.OutlinedSymbols),
                new Symbol(275, "Outlined pentagon", SymbolGroup.OutlinedSymbols),
                new Symbol(276, "Outlined 5-point star", SymbolGroup.OutlinedSymbols),
                new Symbol(277, "Outlined half circle", SymbolGroup.OutlinedSymbols),
                new Symbol(278, "Outlined cresent moon", SymbolGroup.OutlinedSymbols),
                new Symbol(279, "Outlined drop", "Outlined drop symbol", SymbolGroup.OutlinedSymbols),
                new Symbol(280, "Octagon star", "Outlined octagon star", SymbolGroup.OutlinedSymbols),

                new Symbol(281, "Quarter circle segment", "Outlined quarter circle segment", SymbolGroup.LineSegments),
                new Symbol(282, "3-sided outlined square", SymbolGroup.LineSegments),
                new Symbol(283, "2-sided outlined triangle", SymbolGroup.LineSegments),
                new Symbol(284, "Soft handlebars", SymbolGroup.LineSegments),
                new Symbol(285, "Hard handlebars", SymbolGroup.LineSegments),
                new Symbol(286, "Soft lightning", SymbolGroup.LineSegments),
                new Symbol(287, "Lightning", SymbolGroup.LineSegments),
                new Symbol(288, "Staircase", SymbolGroup.LineSegments),
                new Symbol(289, "Ascending lines", SymbolGroup.LineSegments),

                new Symbol(290, "Arrow", "Filled thick right arrow", SymbolGroup.FilledSymbols),
                new Symbol(291, "Outlined arrow", "Outlined right arrow", SymbolGroup.OutlinedSymbols),
                new Symbol(292, "Thin arrow", "Filled thin right arrow", SymbolGroup.FilledSymbols),

                new Symbol(321, "Various 1", "Various symbol 1", SymbolGroup.VariousSymbols),
                new Symbol(322, "Various 2", "Various symbol 2", SymbolGroup.VariousSymbols),
                new Symbol(323, "Various 3", "Various symbol 3", SymbolGroup.VariousSymbols),
                new Symbol(324, "Various 4", "Various symbol 4", SymbolGroup.VariousSymbols),
                new Symbol(325, "Various 5", "Various symbol 5", SymbolGroup.VariousSymbols),
                new Symbol(326, "Various 6", "Various symbol 6", SymbolGroup.VariousSymbols),
                new Symbol(327, "Various 7", "Various symbol 7", SymbolGroup.VariousSymbols),
                new Symbol(328, "Various 8", "Various symbol 8", SymbolGroup.VariousSymbols),
                new Symbol(329, "Various 9", "Various symbol 9", SymbolGroup.VariousSymbols),
                new Symbol(330, "Various 10", "Various symbol 10", SymbolGroup.VariousSymbols),
                new Symbol(331, "Various 11", "Various symbol 11", SymbolGroup.VariousSymbols),
                new Symbol(332, "Various 12", "Various symbol 12", SymbolGroup.VariousSymbols),
                new Symbol(333, "Various 13", "Various symbol 13", SymbolGroup.VariousSymbols),
                new Symbol(334, "Various 14", "Various symbol 14", SymbolGroup.VariousSymbols),
                new Symbol(335, "Various 15", "Various symbol 15", SymbolGroup.VariousSymbols),
                new Symbol(336, "Various 16", "Various symbol 16", SymbolGroup.VariousSymbols),
                new Symbol(337, "Various 17", "Various symbol 17", SymbolGroup.VariousSymbols),
                new Symbol(338, "Various 18", "Various symbol 18", SymbolGroup.VariousSymbols),
                new Symbol(339, "Various 19", "Various symbol 19", SymbolGroup.VariousSymbols),
                new Symbol(340, "Various 20", "Various symbol 20", SymbolGroup.VariousSymbols),
                new Symbol(341, "Various 21", "Various symbol 21", SymbolGroup.VariousSymbols),
                new Symbol(342, "Various 22", "Various symbol 22", SymbolGroup.VariousSymbols),
                new Symbol(343, "Various 23", "Various symbol 23", SymbolGroup.VariousSymbols),
                new Symbol(344, "Various 24", "Various symbol 24", SymbolGroup.VariousSymbols),
                new Symbol(345, "Various 25", "Various symbol 25", SymbolGroup.VariousSymbols),
                new Symbol(346, "Various 26", "Various symbol 26", SymbolGroup.VariousSymbols),
                new Symbol(347, "Various 27", "Various symbol 27", SymbolGroup.VariousSymbols),
                new Symbol(348, "Various 28", "Various symbol 28", SymbolGroup.VariousSymbols),
                new Symbol(349, "Various 29", "Various symbol 29", SymbolGroup.VariousSymbols),
                new Symbol(350, "Various 30", "Various symbol 30", SymbolGroup.VariousSymbols),
                new Symbol(351, "Various 31", "Various symbol 31", SymbolGroup.VariousSymbols),
                new Symbol(352, "Various 32", "Various symbol 32", SymbolGroup.VariousSymbols),
                new Symbol(353, "Various 33", "Various symbol 33", SymbolGroup.VariousSymbols),
                new Symbol(354, "Various 34", "Various symbol 34", SymbolGroup.VariousSymbols),
                new Symbol(355, "Various 35", "Various symbol 35", SymbolGroup.VariousSymbols),
                new Symbol(356, "Various 36", "Various symbol 36", SymbolGroup.VariousSymbols),
                new Symbol(357, "Various 37", "Various symbol 37", SymbolGroup.VariousSymbols),
                new Symbol(358, "Various 38", "Various symbol 38", SymbolGroup.VariousSymbols),
                new Symbol(359, "Various 39", "Various symbol 39", SymbolGroup.VariousSymbols),

                new Symbol(401, "Calligraphy 1", "Calligraphy symbol 1", SymbolGroup.CalligraphySymbols),
                new Symbol(402, "Calligraphy 2", "Calligraphy symbol 2", SymbolGroup.CalligraphySymbols),
                new Symbol(403, "Calligraphy 3", "Calligraphy symbol 3", SymbolGroup.CalligraphySymbols),
                new Symbol(404, "Calligraphy 4", "Calligraphy symbol 4", SymbolGroup.CalligraphySymbols),
                new Symbol(405, "Calligraphy 5", "Calligraphy symbol 5", SymbolGroup.CalligraphySymbols),
                new Symbol(406, "Calligraphy 6", "Calligraphy symbol 6", SymbolGroup.CalligraphySymbols),
                new Symbol(407, "Calligraphy 7", "Calligraphy symbol 7", SymbolGroup.CalligraphySymbols),
                new Symbol(408, "Calligraphy 8", "Calligraphy symbol 8", SymbolGroup.CalligraphySymbols),
                new Symbol(409, "Calligraphy 9", "Calligraphy symbol 9", SymbolGroup.CalligraphySymbols),
                new Symbol(410, "Calligraphy 10", "Calligraphy symbol 10", SymbolGroup.CalligraphySymbols),
                new Symbol(411, "Calligraphy 11", "Calligraphy symbol 11", SymbolGroup.CalligraphySymbols),
                new Symbol(412, "Calligraphy 12", "Calligraphy symbol 12", SymbolGroup.CalligraphySymbols),
                new Symbol(413, "Calligraphy 13", "Calligraphy symbol 13", SymbolGroup.CalligraphySymbols),
                new Symbol(414, "Calligraphy 14", "Calligraphy symbol 14", SymbolGroup.CalligraphySymbols),
                new Symbol(415, "Calligraphy 15", "Calligraphy symbol 15", SymbolGroup.CalligraphySymbols),
                new Symbol(416, "Calligraphy 16", "Calligraphy symbol 16", SymbolGroup.CalligraphySymbols),
                new Symbol(417, "Calligraphy 17", "Calligraphy symbol 17", SymbolGroup.CalligraphySymbols),
                new Symbol(418, "Calligraphy 18", "Calligraphy symbol 18", SymbolGroup.CalligraphySymbols),
                new Symbol(419, "Calligraphy 19", "Calligraphy symbol 19", SymbolGroup.CalligraphySymbols),
                new Symbol(420, "Calligraphy 20", "Calligraphy symbol 20", SymbolGroup.CalligraphySymbols),
                new Symbol(421, "Calligraphy 21", "Calligraphy symbol 21", SymbolGroup.CalligraphySymbols),
                new Symbol(422, "Calligraphy 22", "Calligraphy symbol 22", SymbolGroup.CalligraphySymbols),
                new Symbol(423, "Calligraphy 23", "Calligraphy symbol 23", SymbolGroup.CalligraphySymbols),
                new Symbol(424, "Calligraphy 24", "Calligraphy symbol 24", SymbolGroup.CalligraphySymbols),
                new Symbol(425, "Calligraphy 25", "Calligraphy symbol 25", SymbolGroup.CalligraphySymbols),
                new Symbol(426, "Calligraphy 26", "Calligraphy symbol 26", SymbolGroup.CalligraphySymbols),
                new Symbol(427, "Calligraphy 27", "Calligraphy symbol 27", SymbolGroup.CalligraphySymbols),
                new Symbol(428, "Calligraphy 28", "Calligraphy symbol 28", SymbolGroup.CalligraphySymbols),
                new Symbol(429, "Calligraphy 29", "Calligraphy symbol 29", SymbolGroup.CalligraphySymbols),
                new Symbol(430, "Calligraphy 30", "Calligraphy symbol 30", SymbolGroup.CalligraphySymbols),
                new Symbol(431, "Calligraphy 31", "Calligraphy symbol 31", SymbolGroup.CalligraphySymbols),
                new Symbol(432, "Calligraphy 32", "Calligraphy symbol 32", SymbolGroup.CalligraphySymbols),
                new Symbol(433, "Calligraphy 33", "Calligraphy symbol 33", SymbolGroup.CalligraphySymbols),
                new Symbol(434, "Calligraphy 34", "Calligraphy symbol 34", SymbolGroup.CalligraphySymbols),
                new Symbol(435, "Calligraphy 35", "Calligraphy symbol 35", SymbolGroup.CalligraphySymbols),
                new Symbol(436, "Calligraphy 36", "Calligraphy symbol 36", SymbolGroup.CalligraphySymbols),
                new Symbol(437, "Calligraphy 37", "Calligraphy symbol 37", SymbolGroup.CalligraphySymbols),
                new Symbol(438, "Calligraphy 38", "Calligraphy symbol 38", SymbolGroup.CalligraphySymbols),
                new Symbol(439, "Calligraphy 39", "Calligraphy symbol 39", SymbolGroup.CalligraphySymbols),

                new Symbol(481, "Gradient", SymbolGroup.GradientSymbols),
                new Symbol(482, "Round gradient", SymbolGroup.GradientSymbols),
                new Symbol(483, "Square gradient", SymbolGroup.GradientSymbols),
                new Symbol(484, "Square edge gradient", SymbolGroup.GradientSymbols),
                new Symbol(485, "Cylinder gradient", SymbolGroup.GradientSymbols),
                new Symbol(486, "Gradient 6", "Gradient symbol 6", SymbolGroup.GradientSymbols),
                new Symbol(487, "Gradient 7", "Gradient symbol 7", SymbolGroup.GradientSymbols),
                new Symbol(488, "Gradient 8", "Gradient symbol 8", SymbolGroup.GradientSymbols),
                new Symbol(489, "Gradient 9", "Gradient symbol 9", SymbolGroup.GradientSymbols),
                new Symbol(490, "Sphere gradient 1", SymbolGroup.GradientSymbols),
                new Symbol(491, "Sphere gradient 2", SymbolGroup.GradientSymbols),
                new Symbol(492, "Sphere gradient 3", SymbolGroup.GradientSymbols),
                new Symbol(493, "Sphere gradient 4", SymbolGroup.GradientSymbols),
                new Symbol(494, "Star gradient 1", SymbolGroup.GradientSymbols),
                new Symbol(495, "Star gradient 2", SymbolGroup.GradientSymbols),
                new Symbol(496, "Star gradient 3", SymbolGroup.GradientSymbols),
                new Symbol(497, "Gradient 17", "Gradient symbol 17", SymbolGroup.GradientSymbols),
                new Symbol(498, "Gradient 18", "Gradient symbol 18", SymbolGroup.GradientSymbols),
                new Symbol(499, "Gradient 19", "Gradient symbol 19", SymbolGroup.GradientSymbols),
                new Symbol(500, "Gradient 20", "Gradient symbol 20", SymbolGroup.GradientSymbols),
                new Symbol(501, "Gradient 21", "Gradient symbol 21", SymbolGroup.GradientSymbols),
                new Symbol(502, "Gradient 22", "Gradient symbol 22", SymbolGroup.GradientSymbols),
                new Symbol(503, "Gradient 23", "Gradient symbol 23", SymbolGroup.GradientSymbols),
                new Symbol(504, "Gradient 24", "Gradient symbol 24", SymbolGroup.GradientSymbols),
                new Symbol(505, "Gradient 25", "Gradient symbol 25", SymbolGroup.GradientSymbols),
                new Symbol(506, "Gradient 26", "Gradient symbol 26", SymbolGroup.GradientSymbols),
                new Symbol(507, "Gradient 27", "Gradient symbol 27", SymbolGroup.GradientSymbols),
                new Symbol(508, "Gradient 28", "Gradient symbol 28", SymbolGroup.GradientSymbols),
                new Symbol(509, "Gradient 29", "Gradient symbol 29", SymbolGroup.GradientSymbols),
                new Symbol(510, "Gradient 30", "Gradient symbol 30", SymbolGroup.GradientSymbols),
                new Symbol(511, "Gradient 31", "Gradient symbol 31", SymbolGroup.GradientSymbols),
                new Symbol(512, "Gradient 32", "Gradient symbol 32", SymbolGroup.GradientSymbols),
                new Symbol(513, "Sphere gradient 5", SymbolGroup.GradientSymbols),
                new Symbol(514, "Sphere gradient 6", SymbolGroup.GradientSymbols),
                new Symbol(515, "Sphere gradient 7", SymbolGroup.GradientSymbols),
                new Symbol(516, "Star gradient 4", SymbolGroup.GradientSymbols),
                new Symbol(517, "Star gradient 5", SymbolGroup.GradientSymbols),

                new Symbol(561, "Checkerboard", "Checkerboard pattern", SymbolGroup.Patterns),
                new Symbol(562, "Rhombus pattern", SymbolGroup.Patterns),
                new Symbol(563, "Circle pattern", SymbolGroup.Patterns),
                new Symbol(564, "Dot pattern", SymbolGroup.Patterns),
                new Symbol(565, "Dither pattern", SymbolGroup.Patterns),
                new Symbol(566, "Hexagon pattern", SymbolGroup.Patterns),
                new Symbol(567, "Outlined hexagon pattern", SymbolGroup.Patterns),
                new Symbol(568, "Line pattern 1", SymbolGroup.Patterns),
                new Symbol(569, "Line pattern 2", SymbolGroup.Patterns),
                new Symbol(570, "Line pattern 3", SymbolGroup.Patterns),
                new Symbol(571, "Line pattern 4", SymbolGroup.Patterns),
                new Symbol(572, "Wavy line pattern 1", SymbolGroup.Patterns),
                new Symbol(573, "Wavy line pattern 2", SymbolGroup.Patterns),
                new Symbol(574, "Triangle line pattern 1", SymbolGroup.Patterns),
                new Symbol(575, "Triangle line pattern 2", SymbolGroup.Patterns),
                new Symbol(576, "Wavy line pattern 3", SymbolGroup.Patterns),
                new Symbol(577, "Circle line pattern 1", SymbolGroup.Patterns),
                new Symbol(578, "Circle line pattern 2", SymbolGroup.Patterns),
                new Symbol(579, "Burst pattern 1", SymbolGroup.Patterns),
                new Symbol(580, "Burst pattern 2", SymbolGroup.Patterns),
                new Symbol(581, "Noise pattern", SymbolGroup.Patterns),

                // don't have these either
                new Symbol(641, "Speech bubble 1", SymbolGroup.GameSymbols),
                new Symbol(642, "Speech bubble 2", SymbolGroup.GameSymbols),
                new Symbol(643, "Speech bubble outlined", SymbolGroup.GameSymbols),
                new Symbol(644, "Thought bubble 1", SymbolGroup.GameSymbols),
                new Symbol(645, "Thought bubble 2", SymbolGroup.GameSymbols),
                new Symbol(646, "Thought bubble outlined", SymbolGroup.GameSymbols),
                new Symbol(647, "Square speech bubble", SymbolGroup.GameSymbols),
                new Symbol(648, "Square speech bubble outlined", SymbolGroup.GameSymbols),
                new Symbol(649, "Sword", SymbolGroup.GameSymbols),
                new Symbol(650, "Game symbol 10", SymbolGroup.GameSymbols),
                new Symbol(651, "Game symbol 11", SymbolGroup.GameSymbols),
                new Symbol(652, "Chair", SymbolGroup.GameSymbols),
                new Symbol(653, "Item", SymbolGroup.GameSymbols),
                new Symbol(654, "CD", SymbolGroup.GameSymbols),
                new Symbol(655, "Treasure bag", SymbolGroup.GameSymbols),
                new Symbol(656, "T-shirt", "T-shirt / fashion symbol", SymbolGroup.GameSymbols),
                new Symbol(657, "Game symbol 17", SymbolGroup.GameSymbols),
                new Symbol(658, "Game symbol 18", SymbolGroup.GameSymbols),
                new Symbol(659, "Game symbol 19", SymbolGroup.GameSymbols),
                new Symbol(660, "Hand one", SymbolGroup.GameSymbols),
                new Symbol(661, "Hand zero", SymbolGroup.GameSymbols),
                new Symbol(662, "Hand two", SymbolGroup.GameSymbols),
                new Symbol(663, "Hand stop", SymbolGroup.GameSymbols),
                new Symbol(664, "Smiley", SymbolGroup.GameSymbols),
                new Symbol(665, "Smiley dead", SymbolGroup.GameSymbols),
                new Symbol(666, "Smiley winking", SymbolGroup.GameSymbols),
                new Symbol(667, "Smiley lol", SymbolGroup.GameSymbols),
                new Symbol(668, "Game symbol 28", SymbolGroup.GameSymbols),
                new Symbol(669, "Game symbol 29", SymbolGroup.GameSymbols),
                new Symbol(670, "Game symbol 30", SymbolGroup.GameSymbols),
                new Symbol(671, "Game symbol 31", SymbolGroup.GameSymbols),
                new Symbol(672, "Game symbol 32", SymbolGroup.GameSymbols),
                new Symbol(673, "Game symbol 33", SymbolGroup.GameSymbols),
                new Symbol(674, "Game symbol 34", SymbolGroup.GameSymbols),
                new Symbol(675, "Game symbol 35", SymbolGroup.GameSymbols),
                new Symbol(676, "Game symbol 36", SymbolGroup.GameSymbols),
                new Symbol(677, "Game symbol 37", SymbolGroup.GameSymbols),
                new Symbol(678, "Game symbol 38", SymbolGroup.GameSymbols),
                new Symbol(679, "Game symbol 39", SymbolGroup.GameSymbols),
                new Symbol(680, "Game symbol 40", SymbolGroup.GameSymbols),
                new Symbol(681, "Game symbol 41", SymbolGroup.GameSymbols),
                new Symbol(682, "Game symbol 42", SymbolGroup.GameSymbols),
                new Symbol(683, "Game symbol 43", SymbolGroup.GameSymbols),
                new Symbol(684, "Leaf 1", SymbolGroup.GameSymbols),
                new Symbol(685, "Leaf 2", SymbolGroup.GameSymbols),
                new Symbol(686, "Flower 1", SymbolGroup.GameSymbols),
                new Symbol(687, "Flower 2", SymbolGroup.GameSymbols),
                new Symbol(688, "4-leaf clover", SymbolGroup.GameSymbols),
                new Symbol(689, "Sun", SymbolGroup.GameSymbols),
                new Symbol(690, "Tree", SymbolGroup.GameSymbols),
                new Symbol(691, "Poop", SymbolGroup.GameSymbols),
                new Symbol(692, "Game symbol 52", SymbolGroup.GameSymbols),
                new Symbol(693, "Skull-crossbones", SymbolGroup.GameSymbols),
                new Symbol(694, "Game exclamation", SymbolGroup.GameSymbols),
                new Symbol(695, "Game question", SymbolGroup.GameSymbols),
                new Symbol(696, "Game heart", SymbolGroup.GameSymbols),
                new Symbol(697, "Music note", SymbolGroup.GameSymbols),

                new Symbol(721, "Game portrait 1", SymbolGroup.GamePortraits),
                new Symbol(722, "Game portrait 2", SymbolGroup.GamePortraits),
                new Symbol(723, "Game portrait 3", SymbolGroup.GamePortraits),
                new Symbol(724, "Game portrait 4", SymbolGroup.GamePortraits),
                new Symbol(725, "Game portrait 5", SymbolGroup.GamePortraits),
                new Symbol(726, "Game portrait 6", SymbolGroup.GamePortraits),
                new Symbol(727, "Game portrait 7", SymbolGroup.GamePortraits),
                new Symbol(728, "Rappy 1", SymbolGroup.GamePortraits),
                new Symbol(729, "Rappy 2", SymbolGroup.GamePortraits),
                new Symbol(730, "PSO2 logo", SymbolGroup.GamePortraits),
                new Symbol(731, "Game portrait 11", SymbolGroup.GamePortraits),
                new Symbol(732, "Game portrait 12", SymbolGroup.GamePortraits),
                new Symbol(733, "Game portrait 13", SymbolGroup.GamePortraits),
                new Symbol(734, "Game portrait 14", SymbolGroup.GamePortraits),
                new Symbol(735, "Game portrait 15", SymbolGroup.GamePortraits),
                new Symbol(736, "Game portrait 16", SymbolGroup.GamePortraits),
                new Symbol(737, "Game portrait 17", SymbolGroup.GamePortraits),
                new Symbol(738, "Game portrait 18", SymbolGroup.GamePortraits),
                new Symbol(739, "Game portrait 19", SymbolGroup.GamePortraits),
                new Symbol(740, "Game portrait 20", SymbolGroup.GamePortraits),
                new Symbol(741, "Game portrait 21", SymbolGroup.GamePortraits),
                new Symbol(742, "Game portrait 22", SymbolGroup.GamePortraits),
                new Symbol(743, "Game portrait 23", SymbolGroup.GamePortraits),
                new Symbol(744, "Game portrait 24", SymbolGroup.GamePortraits),
                new Symbol(745, "Game portrait 25", SymbolGroup.GamePortraits),
                new Symbol(746, "Game portrait 26", SymbolGroup.GamePortraits),
                new Symbol(747, "Dudu", SymbolGroup.GamePortraits),
                new Symbol(748, "Game portrait 28", SymbolGroup.GamePortraits),
                new Symbol(749, "Game portrait 29", SymbolGroup.GamePortraits),
                new Symbol(750, "Game portrait 30", SymbolGroup.GamePortraits),
                new Symbol(751, "Game portrait 31", SymbolGroup.GamePortraits),
                new Symbol(752, "Game portrait 32", SymbolGroup.GamePortraits),
                new Symbol(753, "Game portrait 33", SymbolGroup.GamePortraits),
                new Symbol(754, "Game portrait 34", SymbolGroup.GamePortraits),
            };

            _symbolsDict = _symbols.ToDictionary(x => x.Id, x => x);
        }

        public static bool IsKnownSymbolId(int symbol)
        {
            return _symbolsDict.ContainsKey(symbol + 1);
        }

        public static Symbol? GetById(int id)
        {
            return _symbolsDict.TryGetValue(id, out var symbol) ? symbol : null;
        }

        public static string? GetSymbolPackUri(int symbol)
        {
            if (IsKnownSymbolId(symbol))
            {
                return $"pack://application:,,,/OpenSAE.Core;component/assets/{symbol + 1}.png";
            }
            else
            {
                return null;
            }
        }
    }
}
