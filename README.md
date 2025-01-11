# Backsolate (WinForms Frontend)
Image subject isolation/background removal using CNNs on-device (WinForms frontend)

## What is it?
Backsolate is a frontend for several models specializing in detecting subjects in images. This app allows you to use those models to remove backgrounds from the images you input.

## How to use it?
- Download the latest version from the releases.
- Open the app, choose an image by clicking on the left box, and click **Remove Background**.
- The app will now download a model of approximately 160MB.
- Wait until it finishes processing the image.
- After the processing is complete, you can save the image by clicking on the right box.
- If the background removal doesn't work or does not produce desirable results, try using a different model by selecting one from the dropdown on the bottom right.

Experiment with different models until you find the one that works best for you.

## Screenshots
![image](https://github.com/user-attachments/assets/9847de36-94c2-4f4b-b8ae-c99c4552884f)
![Backsolate_jQ76HlPgt3](https://github.com/user-attachments/assets/a5a1aae4-bfa6-42cd-ade8-a91f6e5983da)

## Credits
- u2net, u2netp, u2net_human_seg, u2net_cloth_seg, silueta, isnet-general-use, isnet-anime by [Xuebin Qin](https://github.com/xuebinqin) (https://github.com/xuebinqin/U-2-Net)
- birefnet-general, birefnet-general-lite, birefnet-portrait, birefnet-dis, birefnet-hrsod, birefnet-cod, birefnet-massive by [ZhengPeng7](https://github.com/ZhengPeng7) (https://github.com/ZhengPeng7/BiRefNet)
- ONNX Model Runtime by [Microsoft](https://github.com/microsoft) (https://github.com/microsoft/onnxruntime)
- Model ONNX files from: https://github.com/danielgatis/rembg

## License
This project is licensed under the MIT License.
