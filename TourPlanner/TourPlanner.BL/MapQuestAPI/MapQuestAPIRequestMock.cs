﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TourPlanner.BL.MapQuestAPI
{
    internal class MapQuestAPIRequestMock : IMapQuestAPIRequest
    {
        public JObject? MapQuestResponse { get; private set; } = null;

        public Task ExecuteAsync(string from = "Clarendon Blvd,Arlington,VA", string to = "2400 S Glebe Rd, Arlington, VA", string transportMedium = "pedestrian")
        {
            var jsonString = @"{""route"":{ ""hasTollRoad"":false,""hasBridge"":false,""boundingBox"":{ ""lr"":{ ""lng"":-77.08123,""lat"":38.848927},""ul"":{ ""lng"":-77.091591,""lat"":38.888844} },""distance"":4.923,""hasTimedRestriction"":false,""hasTunnel"":false,""hasHighway"":false,""computedWaypoints"":[],""routeError"":{ ""errorCode"":-400,""message"":""""},""formattedTime"":""01:13:23"",""sessionId"":""62531d4b-016d-6750-02b4-34e8-0e25bc0acdcf"",""hasAccessRestriction"":false,""realTime"":4403,""hasSeasonalClosure"":false,""hasCountryCross"":false,""fuelUsed"":0}";
            MapQuestResponse = JsonConvert.DeserializeObject<JObject>(jsonString);
            return Task.CompletedTask;
        }

        public Task<byte[]> GetRouteImageAsync()
        {
            if (MapQuestResponse == null)
                throw new InvalidOperationException("Image cant be fetched before route data has been received");

            return Task.FromResult(new byte[]
            {
                137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 170,
                0, 0, 0, 30, 8, 6, 0, 0, 0, 188, 45, 133, 225, 0, 0, 21, 36, 73, 68, 65,
                84, 120, 218, 237, 156, 105, 112, 149, 85, 154, 199, 99, 217, 31, 252, 100, 97, 149, 126, 112,
                220, 176, 26, 171, 44, 167, 203, 47, 214, 208, 211, 214, 244, 168, 237, 210, 90, 69, 245, 200,
                76, 105, 117, 151, 218, 210, 109, 73, 107, 151, 213, 216, 75, 41, 42, 10, 168, 32, 136, 162,
                236, 160, 178, 42, 178, 141, 34, 40, 2, 10, 10, 178, 5, 89, 67, 128, 64, 66, 100, 223,
                18, 32, 9, 75, 146, 155, 144, 156, 57, 191, 39, 239, 255, 112, 242, 114, 239, 77, 130, 12,
                51, 31, 72, 213, 195, 125, 239, 121, 207, 123, 150, 231, 252, 207, 255, 89, 206, 123, 41, 40,
                175, 44, 118, 37, 21, 171, 220, 209, 227, 251, 92, 69, 77, 185, 59, 116, 120, 191, 91, 187,
                118, 141, 125, 82, 118, 252, 228, 17, 183, 107, 103, 75, 25, 159, 86, 191, 100, 171, 9, 117,
                78, 157, 172, 49, 217, 191, 102, 180, 171, 91, 251, 156, 107, 168, 41, 11, 101, 8, 207, 35,
                107, 74, 199, 134, 107, 36, 174, 131, 168, 61, 158, 207, 204, 254, 39, 151, 153, 251, 83, 87,
                95, 119, 50, 220, 207, 20, 15, 114, 117, 171, 158, 114, 153, 5, 63, 111, 185, 159, 146, 35,
                75, 255, 236, 246, 149, 111, 176, 186, 180, 83, 83, 85, 233, 254, 244, 167, 158, 238, 23, 191,
                248, 215, 208, 54, 227, 191, 243, 142, 127, 183, 242, 155, 111, 190, 217, 21, 22, 46, 116, 141,
                141, 13, 38, 127, 252, 195, 239, 173, 46, 117, 108, 12, 94, 39, 123, 43, 182, 187, 210, 210,
                109, 238, 192, 129, 3, 238, 182, 219, 110, 51, 233, 217, 179, 167, 227, 239, 116, 93, 157, 155,
                124, 229, 149, 110, 92, 65, 65, 135, 100, 98, 167, 78, 46, 83, 85, 101, 109, 60, 240, 192,
                3, 214, 230, 221, 119, 252, 220, 157, 62, 125, 218, 237, 175, 40, 114, 159, 206, 24, 107, 82,
                187, 99, 154, 205, 153, 113, 240, 125, 238, 220, 79, 109, 126, 31, 142, 31, 230, 70, 12, 29,
                96, 101, 13, 123, 191, 48, 177, 122, 94, 184, 62, 112, 184, 208, 234, 82, 103, 244, 136, 33,
                161, 61, 171, 159, 172, 13, 247, 153, 127, 175, 103, 255, 226, 70, 77, 255, 212, 190, 23, 85,
                30, 113, 11, 246, 31, 181, 231, 89, 159, 173, 107, 231, 219, 243, 180, 195, 125, 244, 39, 161,
                13, 244, 75, 57, 2, 54, 198, 140, 25, 237, 134, 190, 243, 174, 125, 231, 190, 233, 48, 25,
                87, 188, 142, 97, 189, 253, 188, 210, 101, 194, 1, 18, 151, 177, 62, 5, 0, 104, 221, 193,
                175, 237, 65, 129, 150, 142, 1, 45, 34, 80, 49, 64, 26, 16, 96, 213, 8, 131, 64, 65,
                217, 64, 26, 3, 85, 96, 77, 3, 86, 237, 23, 111, 89, 99, 147, 231, 187, 128, 154, 201,
                212, 218, 119, 250, 221, 177, 114, 92, 75, 153, 238, 177, 48, 203, 30, 114, 153, 121, 255, 220,
                10, 176, 140, 131, 49, 49, 94, 148, 199, 130, 160, 60, 218, 6, 152, 215, 93, 119, 157, 41,
                20, 80, 242, 137, 18, 168, 203, 247, 199, 123, 60, 102, 207, 34, 0, 100, 208, 160, 129, 110,
                243, 230, 98, 55, 124, 248, 176, 0, 212, 169, 83, 167, 26, 200, 182, 79, 154, 212, 97, 144,
                74, 54, 143, 28, 105, 109, 188, 245, 214, 91, 161, 221, 162, 117, 43, 93, 77, 77, 181, 141,
                227, 175, 189, 158, 113, 153, 99, 155, 13, 172, 172, 193, 131, 255, 241, 27, 219, 72, 124, 178,
                209, 168, 195, 60, 216, 112, 140, 211, 192, 234, 235, 179, 177, 152, 3, 117, 122, 61, 251, 172,
                221, 167, 222, 127, 253, 231, 111, 220, 63, 254, 246, 23, 35, 30, 116, 113, 255, 253, 191, 182,
                114, 218, 225, 154, 182, 209, 143, 54, 45, 243, 70, 111, 180, 131, 80, 151, 58, 172, 187, 54,
                60, 194, 179, 189, 123, 63, 103, 159, 136, 198, 213, 167, 111, 191, 51, 227, 242, 107, 152, 13,
                144, 185, 68, 64, 141, 201, 140, 245, 48, 160, 10, 164, 8, 147, 1, 52, 12, 40, 6, 170,
                36, 102, 81, 6, 209, 88, 212, 39, 39, 72, 99, 160, 170, 45, 129, 53, 6, 172, 24, 155,
                250, 198, 36, 9, 232, 232, 139, 177, 24, 32, 147, 50, 174, 97, 86, 250, 164, 127, 19, 63,
                126, 99, 91, 129, 117, 241, 175, 173, 29, 128, 137, 194, 81, 60, 109, 3, 76, 49, 41, 139,
                247, 187, 223, 253, 214, 22, 120, 213, 87, 147, 173, 28, 246, 160, 173, 204, 246, 49, 166, 100,
                88, 37, 147, 169, 115, 163, 71, 141, 12, 128, 218, 180, 105, 147, 129, 108, 225, 131, 15, 158,
                51, 80, 231, 119, 235, 102, 109, 204, 155, 55, 47, 180, 187, 96, 246, 120, 87, 123, 162, 178,
                21, 80, 25, 7, 227, 1, 160, 154, 199, 150, 242, 150, 113, 253, 225, 241, 71, 195, 92, 196,
                172, 98, 74, 54, 40, 207, 195, 192, 0, 136, 121, 162, 75, 64, 200, 162, 107, 195, 246, 127,
                165, 183, 213, 65, 108, 222, 94, 164, 11, 64, 46, 28, 72, 111, 218, 216, 34, 2, 198, 74,
                249, 132, 201, 99, 12, 92, 180, 43, 192, 242, 44, 117, 219, 3, 206, 152, 180, 178, 1, 181,
                182, 254, 132, 43, 128, 77, 17, 153, 126, 1, 149, 221, 41, 211, 159, 77, 2, 72, 1, 72,
                14, 26, 143, 7, 17, 183, 207, 247, 45, 187, 103, 6, 192, 138, 169, 249, 172, 253, 252, 103,
                1, 108, 165, 223, 79, 63, 195, 152, 254, 147, 197, 16, 227, 25, 88, 189, 104, 131, 208, 38,
                227, 62, 176, 248, 207, 230, 30, 216, 230, 241, 245, 97, 4, 22, 138, 205, 192, 39, 139, 142,
                146, 251, 246, 235, 99, 247, 88, 116, 49, 172, 76, 156, 152, 133, 121, 241, 215, 183, 111, 223,
                0, 168, 253, 251, 247, 91, 217, 180, 46, 93, 206, 25, 168, 60, 203, 223, 218, 181, 107, 207,
                48, 245, 251, 3, 93, 131, 215, 105, 43, 160, 38, 166, 95, 64, 181, 141, 147, 152, 120, 54,
                149, 172, 133, 92, 21, 0, 3, 0, 41, 67, 215, 176, 36, 115, 102, 158, 128, 209, 24, 206,
                215, 19, 80, 97, 62, 76, 62, 194, 124, 105, 7, 189, 132, 118, 217, 0, 190, 76, 160, 100,
                115, 139, 160, 84, 70, 219, 244, 195, 154, 160, 99, 24, 150, 231, 89, 79, 202, 219, 11, 208,
                124, 64, 69, 2, 80, 229, 167, 198, 140, 154, 15, 164, 242, 25, 13, 168, 126, 231, 183, 53,
                8, 129, 52, 27, 248, 191, 47, 157, 218, 2, 50, 239, 31, 5, 86, 140, 24, 18, 22, 141,
                119, 103, 201, 190, 133, 214, 158, 198, 80, 177, 122, 144, 41, 70, 130, 194, 216, 68, 40, 154,
                69, 71, 161, 44, 14, 74, 133, 149, 88, 44, 177, 15, 190, 27, 236, 193, 61, 153, 53, 245,
                67, 93, 254, 88, 108, 1, 234, 240, 225, 195, 86, 246, 113, 231, 206, 231, 12, 84, 158, 77,
                3, 117, 202, 232, 190, 174, 161, 254, 100, 0, 42, 22, 193, 54, 162, 159, 131, 76, 190, 185,
                88, 190, 140, 123, 248, 143, 49, 160, 40, 3, 200, 60, 143, 153, 134, 25, 1, 46, 223, 1,
                15, 115, 166, 14, 117, 5, 84, 64, 121, 60, 227, 93, 159, 19, 39, 109, 99, 112, 79, 254,
                59, 122, 4, 164, 102, 225, 252, 61, 198, 64, 91, 218, 200, 128, 144, 49, 1, 94, 109, 108,
                202, 4, 116, 197, 57, 237, 1, 169, 88, 147, 54, 32, 72, 230, 161, 57, 129, 45, 214, 178,
                32, 6, 168, 192, 164, 224, 35, 27, 72, 105, 48, 4, 54, 137, 153, 180, 235, 148, 47, 146,
                11, 228, 217, 6, 76, 127, 0, 4, 22, 109, 21, 36, 121, 95, 148, 193, 2, 76, 177, 239,
                198, 242, 9, 246, 29, 165, 216, 51, 158, 57, 181, 160, 10, 4, 197, 206, 148, 17, 124, 176,
                40, 44, 172, 88, 51, 102, 4, 22, 17, 133, 179, 184, 40, 74, 126, 152, 128, 220, 216, 208,
                224, 6, 15, 126, 35, 0, 106, 203, 150, 45, 6, 178, 47, 238, 185, 231, 156, 129, 250, 249,
                157, 119, 182, 184, 15, 11, 23, 134, 118, 231, 206, 28, 231, 78, 213, 182, 0, 149, 32, 71,
                193, 72, 26, 168, 154, 103, 12, 84, 190, 195, 152, 232, 68, 214, 65, 126, 163, 204, 187, 98,
                12, 230, 23, 155, 126, 91, 67, 214, 51, 177, 64, 248, 178, 177, 75, 33, 247, 131, 182, 24,
                3, 100, 194, 154, 208, 166, 172, 21, 64, 198, 250, 209, 190, 128, 90, 180, 126, 85, 88, 35,
                243, 249, 189, 206, 45, 158, 73, 216, 63, 180, 157, 244, 45, 210, 59, 75, 112, 241, 124, 157,
                2, 249, 167, 242, 33, 5, 156, 108, 187, 33, 102, 82, 58, 3, 56, 12, 50, 155, 249, 111,
                15, 72, 85, 15, 96, 153, 153, 139, 64, 154, 102, 209, 184, 205, 56, 11, 97, 227, 74, 124,
                84, 57, 239, 26, 63, 155, 10, 133, 139, 165, 226, 12, 128, 178, 2, 48, 130, 252, 58, 177,
                2, 247, 97, 83, 22, 243, 248, 241, 26, 55, 103, 214, 132, 0, 168, 217, 179, 103, 27, 200,
                54, 12, 26, 116, 206, 64, 93, 211, 167, 143, 181, 49, 106, 212, 168, 208, 110, 241, 250, 229,
                238, 68, 117, 197, 25, 211, 239, 231, 36, 171, 16, 3, 85, 254, 115, 54, 70, 5, 60, 204,
                135, 177, 163, 27, 216, 73, 190, 167, 216, 41, 102, 84, 54, 169, 130, 97, 5, 100, 176, 176,
                252, 81, 185, 89, 242, 245, 9, 208, 4, 54, 218, 22, 80, 181, 177, 99, 160, 242, 140, 172,
                66, 62, 16, 50, 71, 214, 94, 108, 207, 24, 192, 162, 97, 34, 1, 183, 153, 126, 128, 42,
                31, 53, 211, 80, 231, 154, 155, 155, 93, 83, 83, 147, 165, 75, 184, 70, 248, 107, 110, 202,
                184, 230, 198, 90, 19, 255, 143, 59, 221, 212, 224, 37, 99, 159, 238, 116, 157, 151, 122, 215,
                236, 154, 195, 51, 141, 13, 153, 188, 0, 21, 240, 25, 160, 252, 210, 32, 94, 161, 217, 82,
                26, 180, 37, 214, 68, 81, 241, 189, 144, 14, 241, 207, 42, 8, 179, 197, 137, 124, 60, 88,
                83, 139, 205, 51, 90, 20, 22, 13, 197, 202, 42, 196, 140, 186, 116, 233, 18, 183, 173, 164,
                36, 0, 234, 153, 103, 158, 49, 125, 156, 58, 120, 208, 189, 255, 147, 159, 116, 24, 164, 60,
                83, 83, 86, 102, 109, 60, 232, 3, 50, 218, 252, 229, 191, 221, 222, 146, 125, 56, 116, 40,
                97, 212, 103, 91, 8, 32, 97, 185, 24, 168, 230, 107, 250, 185, 10, 168, 184, 46, 140, 219,
                230, 239, 159, 145, 79, 202, 39, 25, 0, 54, 35, 155, 80, 49, 135, 216, 85, 217, 3, 64,
                141, 192, 148, 204, 29, 128, 243, 28, 247, 96, 87, 252, 88, 69, 255, 232, 72, 236, 168, 54,
                232, 7, 128, 138, 217, 169, 47, 211, 79, 95, 184, 101, 136, 252, 99, 198, 41, 11, 14, 65,
                10, 31, 34, 76, 97, 70, 238, 39, 245, 2, 80, 245, 160, 64, 121, 62, 254, 104, 43, 6,
                18, 236, 166, 29, 106, 129, 10, 180, 159, 37, 39, 10, 147, 82, 31, 19, 159, 6, 106, 156,
                227, 205, 182, 9, 76, 137, 137, 43, 34, 95, 78, 233, 22, 20, 138, 27, 96, 172, 2, 91,
                251, 157, 140, 47, 68, 185, 130, 45, 68, 10, 66, 8, 88, 250, 247, 239, 103, 243, 185, 239,
                190, 251, 12, 84, 93, 187, 118, 117, 59, 118, 236, 104, 241, 49, 251, 245, 235, 48, 80, 87,
                122, 16, 242, 247, 221, 119, 223, 5, 240, 255, 227, 185, 231, 172, 172, 184, 124, 135, 141, 5,
                166, 195, 111, 20, 80, 41, 131, 101, 229, 163, 50, 7, 230, 66, 185, 185, 50, 126, 13, 197,
                124, 108, 70, 88, 21, 176, 33, 74, 69, 193, 116, 178, 22, 232, 132, 231, 4, 106, 158, 1,
                200, 220, 227, 19, 29, 80, 159, 13, 162, 20, 20, 109, 107, 13, 4, 84, 158, 103, 83, 197,
                22, 24, 38, 166, 156, 117, 98, 205, 193, 21, 215, 90, 47, 197, 68, 138, 139, 130, 21, 247,
                215, 34, 205, 216, 29, 212, 26, 23, 196, 254, 233, 249, 4, 170, 243, 76, 27, 59, 195, 150,
                86, 194, 7, 5, 156, 202, 135, 38, 209, 189, 229, 72, 19, 208, 242, 157, 129, 201, 39, 77,
                231, 216, 100, 238, 149, 73, 8, 192, 199, 45, 241, 140, 114, 98, 253, 235, 103, 130, 60, 114,
                145, 248, 212, 73, 26, 75, 11, 101, 0, 246, 99, 146, 185, 137, 19, 231, 244, 47, 32, 219,
                248, 43, 87, 123, 107, 226, 23, 246, 211, 105, 103, 177, 106, 83, 99, 163, 251, 242, 254, 251,
                59, 228, 155, 242, 76, 38, 147, 113, 15, 63, 252, 112, 104, 111, 91, 209, 119, 238, 148, 47,
                87, 4, 14, 72, 109, 76, 164, 229, 18, 115, 29, 204, 126, 50, 182, 120, 220, 154, 7, 160,
                130, 65, 21, 241, 3, 96, 88, 13, 192, 1, 30, 43, 243, 122, 64, 111, 244, 131, 14, 213,
                6, 247, 12, 44, 222, 255, 135, 93, 117, 248, 131, 136, 69, 181, 6, 74, 79, 41, 66, 87,
                212, 175, 188, 183, 4, 208, 203, 181, 139, 201, 69, 160, 76, 3, 85, 41, 210, 146, 228, 176,
                133, 13, 19, 128, 202, 5, 236, 133, 156, 87, 160, 54, 212, 100, 61, 65, 82, 170, 73, 169,
                37, 177, 100, 200, 149, 122, 192, 42, 117, 149, 235, 244, 74, 169, 35, 99, 207, 148, 35, 206,
                9, 25, 237, 29, 45, 26, 23, 88, 21, 37, 202, 183, 213, 169, 135, 204, 165, 61, 159, 222,
                64, 140, 207, 151, 85, 174, 120, 193, 234, 87, 84, 84, 184, 211, 190, 207, 223, 118, 191, 39,
                128, 107, 220, 184, 113, 1, 172, 203, 61, 112, 219, 114, 3, 150, 61, 245, 148, 213, 229, 175,
                143, 247, 81, 213, 206, 227, 191, 127, 196, 202, 234, 202, 103, 218, 201, 144, 49, 105, 60, 30,
                255, 41, 192, 218, 88, 147, 252, 177, 210, 73, 98, 88, 192, 166, 136, 95, 81, 51, 130, 107,
                64, 57, 12, 105, 126, 175, 127, 110, 192, 214, 19, 214, 151, 233, 204, 247, 69, 155, 128, 2,
                12, 40, 96, 37, 95, 203, 220, 117, 16, 19, 175, 1, 250, 133, 97, 179, 69, 246, 2, 153,
                0, 7, 224, 149, 238, 76, 131, 50, 46, 19, 241, 196, 196, 25, 183, 95, 16, 39, 224, 241,
                75, 207, 219, 95, 227, 241, 22, 22, 69, 177, 137, 34, 51, 201, 14, 210, 238, 132, 237, 248,
                36, 66, 12, 233, 168, 228, 212, 201, 92, 3, 73, 114, 20, 103, 108, 25, 3, 51, 106, 91,
                190, 143, 192, 136, 232, 88, 215, 252, 96, 223, 151, 54, 69, 218, 93, 176, 69, 79, 28, 121,
                61, 31, 167, 187, 182, 109, 43, 177, 77, 252, 195, 246, 245, 238, 151, 183, 119, 61, 11, 172,
                252, 29, 217, 176, 193, 192, 56, 195, 251, 103, 2, 39, 215, 148, 113, 207, 142, 93, 189, 126,
                227, 156, 236, 175, 238, 184, 221, 237, 219, 183, 215, 29, 247, 11, 22, 124, 57, 64, 41, 151,
                136, 124, 176, 7, 18, 11, 11, 184, 184, 159, 45, 40, 81, 100, 174, 204, 134, 162, 126, 249,
                161, 184, 13, 48, 171, 44, 137, 181, 175, 252, 180, 191, 214, 60, 99, 44, 240, 29, 192, 126,
                191, 117, 126, 43, 192, 224, 50, 96, 222, 241, 239, 211, 32, 141, 83, 145, 0, 81, 177, 207,
                186, 205, 133, 33, 55, 42, 243, 47, 16, 103, 203, 181, 43, 251, 164, 236, 77, 0, 170, 6,
                211, 116, 186, 193, 20, 90, 95, 95, 239, 110, 189, 245, 86, 147, 238, 221, 187, 187, 55, 222,
                120, 195, 117, 238, 220, 217, 93, 126, 249, 229, 166, 224, 69, 139, 22, 185, 85, 171, 86, 185,
                187, 239, 190, 219, 93, 117, 213, 85, 238, 166, 155, 110, 114, 67, 134, 12, 241, 11, 222, 24,
                123, 169, 129, 201, 148, 146, 144, 0, 10, 99, 188, 24, 116, 74, 77, 121, 160, 138, 57, 178,
                137, 22, 5, 112, 1, 190, 180, 159, 26, 187, 7, 10, 170, 96, 70, 101, 38, 164, 244, 24,
                208, 49, 40, 99, 51, 165, 224, 194, 50, 12, 187, 118, 218, 172, 230, 204, 252, 32, 0, 13,
                121, 250, 233, 167, 131, 207, 154, 239, 143, 156, 233, 99, 143, 61, 22, 158, 235, 250, 47, 183,
                185, 194, 111, 102, 184, 186, 218, 83, 110, 202, 196, 177, 230, 115, 110, 152, 221, 203, 196, 116,
                225, 55, 38, 172, 39, 224, 140, 221, 184, 53, 48, 33, 27, 86, 209, 178, 205, 43, 73, 99,
                161, 103, 230, 11, 152, 116, 190, 15, 9, 192, 210, 213, 181, 245, 45, 117, 35, 183, 11, 144,
                202, 39, 151, 153, 21, 171, 10, 168, 134, 143, 36, 207, 173, 51, 125, 36, 125, 30, 159, 43,
                29, 25, 31, 203, 199, 229, 230, 106, 100, 209, 125, 90, 232, 215, 128, 26, 239, 24, 34, 119,
                254, 106, 107, 107, 221, 213, 87, 95, 237, 119, 251, 62, 119, 239, 189, 247, 186, 110, 221, 186,
                249, 133, 218, 101, 172, 178, 100, 201, 18, 215, 165, 75, 23, 119, 203, 45, 183, 248, 136, 120,
                169, 101, 8, 88, 168, 135, 30, 122, 200, 61, 249, 228, 147, 103, 96, 218, 88, 123, 214, 206,
                151, 114, 197, 30, 98, 59, 114, 112, 198, 104, 9, 80, 197, 122, 0, 93, 172, 171, 64, 44,
                155, 114, 210, 64, 69, 9, 33, 240, 72, 249, 196, 156, 92, 97, 26, 165, 4, 1, 59, 95,
                114, 90, 65, 150, 192, 58, 97, 204, 224, 86, 96, 37, 192, 194, 111, 37, 117, 197, 17, 43,
                167, 87, 200, 6, 207, 164, 188, 27, 240, 196, 19, 79, 180, 170, 143, 204, 155, 58, 144, 84,
                138, 219, 177, 98, 76, 120, 129, 132, 177, 113, 13, 104, 1, 36, 192, 68, 4, 86, 125, 231,
                158, 116, 162, 60, 35, 101, 211, 202, 42, 236, 83, 254, 103, 252, 178, 138, 129, 31, 22, 245,
                186, 224, 5, 158, 176, 121, 217, 248, 222, 146, 196, 64, 18, 155, 9, 168, 155, 126, 152, 234,
                86, 173, 158, 110, 230, 94, 47, 161, 8, 224, 121, 79, 153, 146, 224, 72, 64, 213, 97, 15,
                235, 99, 250, 220, 217, 146, 38, 148, 235, 153, 22, 109, 14, 214, 168, 128, 69, 179, 124, 151,
                159, 48, 126, 165, 128, 122, 237, 181, 215, 218, 245, 222, 189, 123, 207, 114, 9, 214, 175, 95,
                239, 118, 238, 220, 217, 170, 12, 22, 190, 230, 154, 107, 92, 117, 117, 117, 130, 212, 38, 27,
                84, 28, 233, 235, 58, 206, 129, 50, 80, 203, 153, 113, 100, 152, 128, 41, 189, 91, 115, 73,
                8, 164, 146, 227, 70, 243, 183, 230, 116, 201, 234, 19, 167, 95, 94, 49, 0, 195, 240, 237,
                120, 105, 66, 129, 130, 249, 106, 123, 22, 217, 244, 94, 255, 91, 183, 179, 192, 215, 94, 121,
                127, 200, 211, 137, 119, 84, 110, 236, 8, 139, 150, 124, 242, 136, 141, 159, 107, 192, 186, 108,
                93, 81, 0, 38, 108, 26, 3, 21, 145, 159, 45, 18, 0, 156, 241, 125, 64, 155, 206, 170,
                224, 86, 196, 230, 212, 14, 112, 148, 235, 76, 189, 175, 161, 35, 80, 64, 42, 115, 15, 67,
                11, 156, 233, 96, 42, 23, 163, 2, 84, 189, 113, 39, 66, 136, 215, 63, 62, 74, 207, 246,
                30, 136, 152, 181, 32, 158, 72, 54, 160, 118, 228, 239, 174, 187, 238, 10, 39, 55, 233, 244,
                84, 204, 78, 98, 76, 64, 166, 193, 152, 226, 147, 113, 104, 119, 7, 16, 34, 145, 219, 16,
                78, 195, 178, 189, 242, 151, 4, 32, 241, 1, 128, 18, 199, 22, 197, 167, 159, 225, 187, 76,
                103, 20, 69, 43, 194, 14, 110, 73, 196, 202, 77, 187, 103, 248, 224, 42, 227, 254, 218, 179,
                123, 135, 65, 58, 224, 239, 221, 91, 252, 213, 146, 183, 90, 111, 32, 78, 225, 62, 255, 153,
                185, 68, 128, 21, 246, 138, 129, 151, 13, 168, 217, 210, 113, 128, 218, 64, 26, 29, 160, 48,
                15, 177, 83, 54, 203, 161, 160, 76, 110, 132, 192, 164, 55, 206, 0, 41, 230, 62, 28, 176,
                232, 101, 32, 47, 90, 207, 216, 7, 141, 205, 190, 114, 163, 177, 153, 87, 26, 44, 253, 146,
                82, 44, 241, 41, 35, 227, 40, 48, 159, 48, 241, 137, 44, 153, 255, 35, 128, 138, 155, 160,
                183, 139, 92, 83, 125, 171, 64, 72, 167, 16, 102, 114, 48, 87, 177, 175, 244, 99, 36, 138,
                138, 81, 184, 64, 31, 191, 166, 120, 214, 139, 52, 73, 126, 82, 193, 74, 187, 251, 74, 178,
                1, 235, 214, 173, 245, 58, 170, 119, 167, 78, 157, 116, 127, 236, 241, 72, 187, 65, 218, 171,
                199, 175, 60, 192, 235, 93, 211, 174, 169, 89, 219, 103, 108, 0, 21, 211, 143, 43, 0, 224,
                242, 1, 21, 161, 14, 108, 26, 252, 207, 68, 223, 106, 19, 125, 199, 199, 202, 217, 14, 96,
                204, 50, 37, 233, 184, 24, 244, 128, 148, 113, 32, 22, 152, 106, 211, 70, 129, 152, 78, 243,
                210, 155, 64, 233, 39, 128, 26, 103, 11, 84, 39, 118, 11, 20, 68, 9, 164, 233, 147, 71,
                243, 81, 229, 3, 34, 205, 167, 127, 60, 80, 139, 138, 138, 90, 24, 213, 183, 37, 112, 10,
                28, 152, 57, 20, 119, 106, 219, 4, 87, 189, 101, 146, 171, 46, 26, 225, 170, 139, 199, 184,
                170, 77, 99, 93, 245, 230, 247, 90, 190, 35, 254, 158, 149, 81, 199, 151, 215, 148, 254, 183,
                171, 42, 251, 194, 85, 149, 127, 229, 106, 118, 46, 114, 213, 187, 150, 186, 234, 138, 50, 87,
                83, 83, 227, 93, 141, 42, 119, 236, 216, 17, 147, 253, 251, 15, 185, 61, 123, 246, 184, 163,
                199, 42, 92, 197, 145, 125, 38, 92, 167, 133, 182, 106, 14, 110, 182, 103, 120, 190, 230, 200,
                222, 208, 118, 104, 127, 239, 42, 171, 119, 200, 247, 83, 93, 185, 219, 234, 85, 87, 29, 179,
                103, 232, 227, 135, 31, 202, 173, 127, 82, 87, 179, 102, 206, 112, 19, 38, 76, 200, 43, 159,
                205, 154, 236, 142, 29, 173, 112, 53, 21, 165, 214, 206, 161, 146, 121, 54, 47, 205, 155, 190,
                246, 149, 46, 181, 147, 48, 73, 225, 214, 50, 183, 100, 207, 209, 32, 133, 59, 247, 180, 250,
                46, 89, 191, 183, 162, 101, 204, 94, 151, 65, 135, 180, 233, 117, 88, 94, 94, 238, 142, 84,
                86, 152, 48, 110, 190, 243, 41, 157, 153, 14, 252, 120, 120, 30, 157, 112, 175, 114, 103, 161,
                251, 161, 104, 190, 91, 185, 124, 137, 201, 158, 141, 179, 93, 85, 241, 251, 173, 218, 14, 194,
                248, 253, 243, 106, 251, 112, 197, 161, 208, 46, 250, 47, 223, 93, 102, 229, 233, 126, 247, 85,
                236, 10, 162, 117, 217, 177, 119, 157, 213, 177, 49, 28, 61, 216, 106, 205, 10, 98, 198, 105,
                230, 40, 52, 7, 80, 235, 234, 234, 220, 234, 213, 171, 91, 149, 85, 86, 86, 6, 83, 159,
                102, 84, 142, 86, 211, 142, 182, 124, 154, 170, 154, 74, 91, 224, 139, 114, 81, 218, 43, 5,
                113, 228, 140, 185, 206, 5, 84, 130, 164, 75, 46, 185, 196, 245, 232, 209, 195, 178, 1, 195,
                134, 13, 115, 157, 58, 117, 114, 31, 124, 240, 65, 43, 160, 110, 222, 188, 57, 1, 106, 198,
                104, 60, 126, 189, 79, 103, 244, 149, 85, 7, 242, 14, 138, 221, 183, 124, 249, 114, 99, 103,
                149, 17, 69, 127, 251, 237, 183, 110, 251, 246, 237, 161, 140, 87, 238, 200, 66, 208, 167, 202,
                200, 64, 172, 89, 179, 38, 124, 223, 189, 123, 183, 61, 71, 134, 162, 184, 184, 184, 85, 63,
                101, 101, 101, 110, 197, 138, 21, 214, 15, 231, 236, 113, 63, 113, 61, 162, 119, 250, 208, 61,
                9, 41, 58, 245, 65, 59, 133, 133, 133, 22, 124, 114, 60, 26, 215, 67, 152, 83, 91, 115,
                204, 55, 174, 108, 253, 180, 87, 39, 23, 74, 175, 252, 100, 71, 243, 101, 156, 60, 211, 214,
                188, 248, 94, 90, 90, 26, 250, 165, 61, 218, 62, 11, 168, 225, 213, 171, 148, 143, 122, 233,
                165, 151, 186, 27, 111, 188, 49, 200, 13, 55, 220, 224, 174, 191, 254, 122, 247, 246, 219, 111,
                187, 43, 174, 184, 194, 61, 250, 232, 163, 150, 23, 188, 242, 202, 43, 67, 157, 203, 46, 187,
                204, 109, 221, 186, 53, 48, 170, 124, 14, 192, 42, 54, 5, 176, 249, 128, 186, 120, 241, 98,
                235, 227, 179, 207, 62, 51, 147, 249, 222, 123, 239, 185, 131, 7, 15, 218, 164, 159, 127, 254,
                121, 75, 247, 168, 46, 19, 166, 140, 180, 144, 202, 184, 255, 242, 203, 47, 155, 210, 248, 142,
                178, 95, 124, 241, 69, 107, 171, 95, 191, 126, 62, 130, 157, 107, 229, 243, 231, 207, 183, 122,
                163, 71, 143, 182, 60, 49, 111, 50, 241, 140, 250, 137, 199, 52, 101, 202, 20, 55, 103, 206,
                28, 187, 215, 187, 119, 239, 96, 206, 103, 205, 154, 101, 101, 180, 203, 243, 239, 190, 251, 174,
                155, 56, 113, 162, 141, 129, 251, 47, 189, 244, 146, 149, 115, 29, 47, 122, 174, 57, 182, 53,
                174, 116, 63, 237, 213, 201, 133, 210, 43, 153, 32, 158, 155, 52, 105, 146, 181, 207, 9, 156,
                54, 115, 174, 121, 241, 43, 135, 145, 35, 71, 90, 29, 54, 7, 63, 207, 1, 176, 103, 1,
                53, 68, 208, 30, 168, 98, 84, 254, 240, 191, 210, 114, 226, 196, 9, 187, 199, 89, 181, 82,
                82, 48, 237, 177, 99, 199, 220, 209, 163, 71, 205, 21, 80, 42, 171, 185, 185, 169, 85, 20,
                23, 255, 106, 32, 23, 80, 217, 213, 239, 188, 243, 142, 249, 40, 43, 87, 174, 116, 27, 55,
                110, 180, 137, 8, 36, 175, 188, 242, 138, 123, 253, 245, 215, 195, 68, 0, 202, 128, 1, 3,
                130, 66, 153, 56, 117, 222, 124, 243, 77, 155, 180, 20, 202, 105, 16, 215, 48, 17, 245, 105,
                11, 37, 139, 9, 88, 48, 44, 196, 151, 95, 126, 217, 38, 80, 95, 120, 225, 133, 179, 0,
                48, 98, 196, 136, 86, 108, 164, 107, 250, 90, 183, 110, 93, 135, 230, 152, 107, 92, 217, 250,
                105, 143, 78, 46, 164, 94, 5, 84, 177, 229, 244, 233, 211, 221, 199, 31, 127, 156, 119, 94,
                92, 15, 28, 56, 208, 45, 91, 182, 204, 198, 144, 214, 87, 0, 42, 209, 175, 242, 157, 228,
                62, 207, 223, 219, 83, 77, 173, 78, 54, 56, 33, 145, 27, 80, 113, 108, 119, 214, 193, 176,
                43, 49, 27, 48, 198, 152, 49, 99, 140, 53, 80, 18, 187, 140, 201, 162, 24, 118, 36, 166,
                152, 250, 40, 110, 252, 248, 241, 65, 161, 40, 145, 197, 228, 228, 140, 29, 155, 86, 40, 74,
                64, 161, 152, 102, 216, 37, 238, 251, 171, 175, 190, 178, 62, 219, 195, 168, 50, 111, 180, 135,
                242, 97, 78, 148, 142, 75, 20, 63, 151, 13, 168, 249, 230, 152, 111, 92, 217, 250, 105, 143,
                78, 46, 164, 94, 5, 212, 111, 190, 249, 198, 198, 13, 115, 98, 218, 243, 205, 139, 107, 54,
                15, 4, 64, 159, 57, 125, 84, 37, 122, 255, 55, 128, 10, 40, 73, 232, 242, 70, 14, 140,
                26, 94, 120, 216, 249, 121, 214, 193, 204, 152, 49, 195, 2, 54, 118, 31, 126, 11, 12, 32,
                197, 105, 231, 127, 253, 245, 215, 182, 227, 113, 49, 152, 232, 71, 31, 125, 20, 20, 138, 9,
                97, 17, 22, 44, 88, 96, 128, 194, 39, 66, 161, 152, 32, 158, 131, 85, 102, 206, 156, 105,
                74, 146, 185, 145, 176, 24, 220, 239, 136, 233, 167, 31, 238, 115, 60, 10, 67, 48, 62, 148,
                158, 15, 168, 249, 230, 152, 107, 92, 0, 44, 91, 63, 237, 209, 201, 133, 212, 107, 108, 250,
                137, 93, 0, 42, 166, 191, 173, 121, 109, 219, 182, 205, 218, 253, 228, 147, 79, 242, 0, 53,
                58, 226, 228, 213, 188, 243, 9, 84, 229, 50, 245, 38, 12, 192, 5, 172, 185, 128, 138, 121,
                195, 135, 130, 1, 216, 173, 2, 14, 187, 89, 10, 229, 40, 23, 5, 80, 143, 29, 46, 133,
                162, 60, 124, 32, 20, 132, 12, 30, 60, 216, 192, 37, 95, 234, 195, 15, 63, 180, 250, 152,
                37, 22, 45, 54, 117, 8, 117, 121, 14, 71, 30, 101, 203, 103, 68, 0, 165, 220, 130, 180,
                233, 143, 133, 133, 196, 140, 229, 3, 106, 190, 57, 230, 26, 23, 253, 103, 235, 167, 45, 157,
                92, 104, 189, 166, 77, 63, 253, 14, 29, 58, 180, 205, 121, 225, 207, 202, 7, 78, 7, 157,
                1, 168, 118, 210, 144, 248, 169, 205, 141, 167, 206, 59, 163, 198, 111, 194, 180, 5, 84, 34,
                80, 94, 110, 129, 57, 20, 89, 178, 19, 241, 129, 164, 80, 202, 135, 15, 31, 238, 250, 247,
                239, 111, 202, 149, 66, 81, 112, 28, 16, 16, 161, 2, 20, 76, 166, 76, 148, 4, 16, 162,
                56, 148, 69, 27, 28, 9, 211, 158, 28, 127, 22, 131, 69, 133, 121, 8, 44, 8, 22, 248,
                20, 80, 117, 150, 143, 249, 36, 29, 87, 82, 82, 98, 230, 24, 191, 47, 54, 113, 217, 128,
                154, 111, 142, 185, 198, 69, 221, 108, 253, 180, 165, 147, 11, 173, 87, 1, 149, 121, 48, 78,
                158, 27, 59, 118, 108, 222, 121, 33, 220, 163, 206, 180, 105, 211, 220, 228, 201, 147, 115, 3,
                85, 167, 19, 167, 143, 172, 49, 176, 234, 39, 39, 65, 56, 8, 224, 167, 38, 77, 25, 251,
                25, 138, 179, 159, 156, 52, 217, 79, 79, 210, 63, 91, 145, 240, 179, 150, 56, 71, 171, 255,
                212, 130, 247, 28, 115, 1, 85, 41, 12, 76, 207, 160, 65, 131, 204, 135, 194, 201, 150, 63,
                38, 133, 18, 65, 42, 176, 144, 66, 81, 30, 10, 136, 131, 141, 215, 94, 123, 205, 118, 123,
                90, 161, 8, 139, 206, 98, 97, 190, 80, 46, 102, 47, 190, 199, 162, 225, 19, 194, 92, 48,
                131, 198, 64, 93, 9, 166, 19, 127, 12, 165, 195, 46, 176, 7, 128, 202, 7, 212, 124, 115,
                140, 199, 5, 187, 112, 95, 169, 178, 108, 253, 180, 165, 147, 11, 173, 87, 1, 21, 97, 156,
                152, 118, 230, 147, 107, 94, 180, 197, 88, 20, 160, 1, 98, 238, 167, 211, 136, 173, 128, 170,
                23, 28, 236, 248, 45, 121, 49, 87, 255, 91, 71, 206, 95, 10, 38, 167, 77, 28, 175, 233,
                231, 16, 58, 87, 79, 159, 251, 234, 204, 54, 31, 163, 254, 95, 8, 202, 130, 53, 94, 125,
                245, 213, 192, 56, 23, 229, 255, 97, 194, 63, 0, 53, 249, 37, 103, 190, 87, 233, 58, 2,
                96, 253, 178, 80, 0, 142, 255, 203, 158, 242, 3, 171, 47, 42, 255, 162, 116, 28, 168, 198,
                166, 9, 184, 114, 1, 53, 215, 79, 159, 197, 162, 2, 112, 120, 187, 41, 15, 128, 43, 183,
                127, 113, 81, 249, 23, 165, 67, 242, 63, 124, 127, 216, 246, 189, 155, 38, 172, 0, 0, 0,
                0, 73, 69, 78, 68, 174, 66, 96, 130,
            });
        }
    }
}
