/* Copyright 2016 Google Inc. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#ifndef VR_GVR_DEMOS_VIDEO_PLUGIN_FRAME_BUFFER_H_
#define VR_GVR_DEMOS_VIDEO_PLUGIN_FRAME_BUFFER_H_

#include <GLES2/gl2.h>

#include "external_texture.h"

namespace gvrvideo {

// Allocates and configures a framebuffer used to transfer the video texture to
// the externally provided texture.
class FrameBuffer {
 public:
  FrameBuffer() : externalTexture(), framebufferID(0) {}

  FrameBuffer(ExternalTexture &external_texture) {
    this->externalTexture = external_texture;
  }

  ~FrameBuffer();

  // Returns the texture that is attached as the color attachment to this frame
  // buffer.
  const ExternalTexture &GetExternalTexture() const { return externalTexture; }

  // Reinitialize the framebuffer and binds the given external texture.
  bool ReInitialize(const ExternalTexture &texture);

  // Binds the frame buffer to the gl context.
  // returns true if successful.
  bool Bind();

 private:
  ExternalTexture externalTexture;
  GLuint framebufferID;

  // Initializes the framebufffer and binds the external texture to the color
  // attachment.
  bool Initialize();
};
}  // namespace gvrvideo

#endif  // VR_GVR_DEMOS_VIDEO_PLUGIN_FRAME_BUFFER_H_
