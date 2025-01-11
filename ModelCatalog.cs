using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backsolate
{
    public class ModelCatalog
    {
        public static Dictionary<string, string> Models = new Dictionary<string, string>
        {
            { "u2net", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/u2net.onnx" },
            { "u2netp", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/u2netp.onnx" },
            { "u2net_human_seg", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/u2net_human_seg.onnx" },
            { "u2net_cloth_seg", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/u2net_cloth_seg.onnx" },
            { "silueta", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/silueta.onnx" },
            { "isnet-general-use", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/isnet-general-use.onnx" },
            { "isnet-anime", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/isnet-anime.onnx" },
            { "birefnet-general", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/BiRefNet-general-epoch_244.onnx" },
            { "birefnet-general-lite", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/BiRefNet-general-bb_swin_v1_tiny-epoch_232.onnx" },
            { "birefnet-portrait", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/BiRefNet-portrait-epoch_150.onnx" },
            { "birefnet-dis", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/BiRefNet-DIS-epoch_590.onnx" },
            { "birefnet-hrsod", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/BiRefNet-HRSOD_DHU-epoch_115.onnx" },
            { "birefnet-cod", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/BiRefNet-COD-epoch_125.onnx" },
            { "birefnet-massive", "https://github.com/danielgatis/rembg/releases/download/v0.0.0/BiRefNet-massive-TR_DIS5K_TR_TEs-epoch_420.onnx" }
        };

        public static Dictionary<string, int> ModelPreferredSize = new Dictionary<string, int>
    {
        { "u2net", 320 },
        { "u2netp", 320 },
        { "u2net_human_seg", 320 },
        { "u2net_cloth_seg", 320 },
        { "silueta", 320 },
        { "isnet-general-use", 1024 },
        { "isnet-anime", 1024 },
        { "birefnet-general", 1024 },
        { "birefnet-general-lite", 256},
        { "birefnet-portrait", 512 },
        { "birefnet-dis", 640 },
        { "birefnet-hrsod", 640},
        { "birefnet-cod", 640},
        { "birefnet-massive", 640 }
    };
    }
}
