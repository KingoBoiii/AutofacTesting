namespace AutofacTesting.Extensions.OpenGL.Enums;

/*
 	public const uint GL_STREAM_DRAW = 0x88E0;
	public const uint GL_STREAM_READ = 0x88E1;
	public const uint GL_STREAM_COPY = 0x88E2;
	public const uint GL_STATIC_DRAW = 0x88E4;
	public const uint GL_STATIC_READ = 0x88E5;
	public const uint GL_STATIC_COPY = 0x88E6;
	public const uint GL_DYNAMIC_DRAW = 0x88E8;
	public const uint GL_DYNAMIC_READ = 0x88E9;
	public const uint GL_DYNAMIC_COPY = 0x88EA;
 */

public enum GLBufferUsage : uint
{
	None = 0,
	StreamDraw = GLConstants.GL_STREAM_DRAW,
	StreamRead = GLConstants.GL_STREAM_READ, 
	StreamCopy = GLConstants.GL_STREAM_COPY, 
	StaticDraw = GLConstants.GL_STATIC_DRAW, 
	StaticRead = GLConstants.GL_STATIC_READ, 
	StatisCopy = GLConstants.GL_STATIC_COPY, 
	DynamicDraw = GLConstants.GL_DYNAMIC_DRAW,
	DynamicRead = GLConstants.GL_DYNAMIC_READ,
	DynamicCopy = GLConstants.GL_DYNAMIC_COPY
}
