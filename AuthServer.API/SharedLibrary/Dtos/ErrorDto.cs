using System;

namespace SharedLibrary.Dtos;

public class ErrorDto
{
    public List<String> Errors { get; private set; }
    public bool IsShow { get; set; }

    public ErrorDto()
    {
        Errors = new List<string>();
    }
    public ErrorDto(string error, bool isShow)
    {
        Errors = new List<string>();
        Errors.Add(error);
        IsShow = isShow;
    }
    public ErrorDto(List<string> errors, bool isShow)
    {
        Errors = errors;
        IsShow = isShow;
    }
}
