# Convert to text using pandoc

$fromlang = $args[0]
$tolang = $args[1]
$dir = $args[2]

echo "Setting $fromlang to $tolang on XLIFF target language"

Get-ChildItem "$dir\\*.xlf" |  ForEach-Object { 
    $src = $($_.FullName)
    $dst = $src 

    $content = [System.IO.File]::ReadAllText($src)
    $content = $content.Replace("target-language=""$fromlang""","target-language=""$tolang""")
    [System.IO.File]::WriteAllText($dst, $content)
} 
