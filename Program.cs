// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using SDL3;

Console.WriteLine("Hello, World!");

const int width = 800;
const int height = 600;

const float squareSize = 40;

if (!SDL.Init(SDL.InitFlags.Video))
{
    Console.WriteLine($"SDL initialization failed: {SDL.GetError()}");
    return;
}

if (!SDL.CreateWindowAndRenderer(
        "Moving Square", width, height, 0, out var window, out var renderer))
{
    Console.WriteLine($"Could not create window: {SDL.GetError()}");
    SDL.Quit();
}

var running = true;
var timer = Stopwatch.StartNew();

while (running)
{
    while (SDL.PollEvent(out var eventData))
    {
        if (eventData.Type == (uint)SDL.EventType.Quit)
        {
            running = false;
        }

        float x = (float)(timer.Elapsed.TotalSeconds * 120 % (width - squareSize));
        float y = height / 2f - squareSize / 2f;
        SDL.SetRenderDrawColor(renderer, 25, 25, 35, 255);
        SDL.RenderClear(renderer);
        
        SDL.SetRenderDrawColor(renderer, 80, 200, 255, 255);
        SDL.RenderLine(renderer, x, y, x + squareSize, y);
        SDL.RenderLine(renderer, x + squareSize, y, x + squareSize, y + squareSize);
        SDL.RenderLine(renderer, x + squareSize, y + squareSize, x, y + squareSize);
        SDL.RenderLine(renderer, x, y + squareSize, x, y);

        SDL.RenderPresent(renderer);
        
        

    }
    
    
}

SDL.DestroyRenderer(renderer);
SDL.DestroyWindow(window);
SDL.Quit();


    
    
