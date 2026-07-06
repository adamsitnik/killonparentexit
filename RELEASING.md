# Releasing a New Version

This project uses GitHub Actions to automatically build and publish releases.

## Steps

1. Decide on the version number (e.g., `1.0.0`).

2. Create and push a tag:

   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

3. The [release workflow](.github/workflows/release.yml) will automatically:
   - Build self-contained executables for `linux-x64` and `win-x64`
   - Create a GitHub Release with auto-generated release notes
   - Attach the built executables (`killonparentexit` and `killonparentexit.exe`) to the release

4. Once the workflow completes, verify the release on the [Releases page](../../releases).
