# Convert to text using pandoc

$dir = $args[0]
echo "Converting $dir to HTML"
cd $dir

Get-ChildItem -R *.md |  ForEach-Object{ 
    $src = $($_.FullName)
    $dst = $($_.FullName) -replace '.md','.htm'
    &pandoc -f markdown  -t html $src -o $dst --wrap none --standalone
    
} 
cd ..