# Apply-CodexPatch.ps1
# This script reads a Codex patch from the clipboard and applies it using git apply.

# Optional: make sure you’re in a Git repo
if (-not (Test-Path ".git")) {
    Write-Error "You're not in a Git repository. Please navigate to the root of your repo and try again."
    exit 1
}

# Save clipboard content to a temporary patch file
$tempPatchFile = "$env:TEMP\codex_patch.patch"
$clipboardText = Get-Clipboard
Set-Content -Path $tempPatchFile -Value $clipboardText -Encoding UTF8

# Show preview
Write-Host "`n🔍 Previewing patch from clipboard:`n"
$clipboardText | Out-Host

# Confirm before applying
$apply = Read-Host "`nApply this patch to your Git repo? (y/n)"
if ($apply -ne "y") {
    Write-Host "❌ Patch not applied."
    exit 0
}

# Apply patch
git apply $tempPatchFile

if ($LASTEXITCODE -eq 0) {
    Write-Host "`n✅ Patch applied successfully."
    Write-Host "📂 Run 'git diff' to review changes, then commit and push as needed."
} else {
    Write-Error "`n❌ Failed to apply patch. Check if it’s already applied or malformed."
}
