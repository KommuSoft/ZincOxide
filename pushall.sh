for r in {origin,github,codeplex}
do
	for b in {master,type-system}
	do
		git push $r $b
	done
done
