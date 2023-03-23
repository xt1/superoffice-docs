# Convert to text using pandoc

$dir = $args[0]
echo "Converting $dir to Markdown"

cd $dir
Get-ChildItem -R *.htm |  ForEach-Object{ 
    $src = $($_.FullName)
    $dst = $($_.FullName) -replace '.htm','.md'
    &pandoc -t markdown  -f html $src -o $dst  --standalone
} 
cd ..