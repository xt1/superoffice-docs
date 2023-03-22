# Convert to text using pandoc

$lang = $args[0]
echo "Setting $lang on files"
cd $lang

Get-ChildItem -R *.htm | Rename-item -NewName { $_.Name -replace '.htm',"_$lang.htm" }
Get-ChildItem -R *.html | Rename-item -NewName { $_.Name -replace '.html',"_$lang.htm" }

echo "Converting HTML to Text"
Get-ChildItem -R *.htm |  ForEach-Object{ 
    $src = $($_.FullName)
    $dst = "text\\" + $($_.Name) -replace '.htm','.txt'
    &pandoc -f html -t plain $src -o $dst --wrap none --standalone

    # now clean out box art
    $content = [System.IO.File]::ReadAllText($dst)
    $content = $content.Replace("[]","")
    $content = $content.Replace("+--","")
    $content = $content.Replace("--+","")
    $content = $content.Replace("--","")
    $content = $content.Replace("|","")
    [System.IO.File]::WriteAllText($dst, $content)
    
} 

cd ..
